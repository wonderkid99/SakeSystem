using System;
using System.Globalization;

namespace SakeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup format mata uang Indonesia (Rupiah)
            CultureInfo cultureInfo = new CultureInfo("id-ID");
            
            // Variabel Akumulator Global (Requirement 1: Looping & Akumulasi)
            double totalSeluruhBonusKeluar = 0;

            Console.WriteLine("=================================================");
            Console.WriteLine("   PT. CEPAT SAMPAI - SYSTEM S.A.K.E v1.0 (C#)");
            Console.WriteLine("=================================================");

            // Requirement 1: Looping (While True)
            while (true)
            {
                Console.WriteLine("\n--- Input Data Karyawan (Ketik 'EXIT' pada nama untuk keluar) ---");
                
                Console.Write("Nama Karyawan: ");
                string nama = Console.ReadLine() ?? "";

                // Cek kondisi keluar (Case Insensitive)
                if (string.Equals(nama, "EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Menu Jabatan
                Console.WriteLine("Pilih Posisi Jabatan:");
                Console.WriteLine("1. Manajer");
                Console.WriteLine("2. Staf Senior");
                Console.WriteLine("3. Staf Junior");
                Console.WriteLine("4. Lainnya (Non-Struktural)");
                Console.Write("Masukkan Pilihan (1-4): ");
                
                int pilihanJabatan = 0;
                // Validasi input angka (Try-Catch ala C#)
                try
                {
                    pilihanJabatan = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Input jabatan harus angka!");
                    continue; // Skip ke loop selanjutnya
                }

                // Requirement 2: Switch-Case (Penentuan Posisi)
                double tunjanganDasar = 0;
                string namaJabatan = "";

                switch (pilihanJabatan)
                {
                    case 1:
                        tunjanganDasar = 500000;
                        namaJabatan = "Manajer";
                        break;
                    case 2:
                        tunjanganDasar = 350000;
                        namaJabatan = "Staf Senior";
                        break;
                    case 3:
                        tunjanganDasar = 200000;
                        namaJabatan = "Staf Junior";
                        break;
                    default:
                        tunjanganDasar = 50000;
                        namaJabatan = "Non-Struktural";
                        break;
                }

                Console.Write("Masukkan Total Jam Lembur Bulan Ini: ");
                int jamLembur = 0;
                try
                {
                    jamLembur = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    jamLembur = 0; // Default 0 jika error
                }

                // Requirement 3: IF-Else-If Logic Kompleks (Bonus Lembur)
                double persentaseBonus = 0;
                string statusLoyalitas = "";

                if (jamLembur >= 40)
                {
                    persentaseBonus = 0.25; // 25%
                    statusLoyalitas = "Sangat Loyal";
                }
                else if (jamLembur >= 20)
                {
                    persentaseBonus = 0.15; // 15%
                    statusLoyalitas = "Cukup Loyal";
                }
                else if (jamLembur >= 1)
                {
                    persentaseBonus = 0.05; // 5%
                    statusLoyalitas = "Normal";
                }
                else
                {
                    persentaseBonus = 0.0;
                    statusLoyalitas = "Nihil";
                }

                // Kalkulasi Akhir
                double bonusTambahan = tunjanganDasar * persentaseBonus;
                double totalBonusIndividu = tunjanganDasar + bonusTambahan;

                // Update Total Global
                totalSeluruhBonusKeluar += totalBonusIndividu;

                // Output Rangkuman (Menggunakan String Interpolation $)
                // "C" adalah format Currency otomatis berdasarkan CultureInfo
                Console.WriteLine($"\n--- Rangkuman Audit: {nama} ---");
                Console.WriteLine($"Jabatan        : {namaJabatan}");
                Console.WriteLine($"Tunjangan Dasar: {tunjanganDasar.ToString("C", cultureInfo)}");
                Console.WriteLine($"Jam Lembur     : {jamLembur} jam ({statusLoyalitas})");
                Console.WriteLine($"Bonus Lembur   : {bonusTambahan.ToString("C", cultureInfo)}");
                Console.WriteLine($"Total Terima   : {totalBonusIndividu.ToString("C", cultureInfo)}");

                // Requirement 4: Peringatan Kinerja (Simple If)
                if (totalBonusIndividu > 600000)
                {
                    Console.WriteLine("Status Kinerja : [Karyawan Kinerja Prima Bulan Ini!]");
                }
                else
                {
                    Console.WriteLine("Status Kinerja : [Kinerja Stabil]");
                }

                // Tampilkan Global Accumulator
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($">> Total Uang Keluar Perusahaan (Global): {totalSeluruhBonusKeluar.ToString("C", cultureInfo)}");
                Console.WriteLine("-------------------------------------------------");
            }

            // Output Final setelah loop berhenti
            Console.WriteLine("\nSistem dimatikan.");
            Console.WriteLine($"TOTAL AKHIR BONUS DIBAYARKAN: {totalSeluruhBonusKeluar.ToString("C", cultureInfo)}");
        }
    }
}