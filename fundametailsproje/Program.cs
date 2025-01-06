using System;

namespace CSharpFundamentalsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //sonsuz döngü ile kullanıcıya tekrar tekrar menü açılacaktır
            {
                Console.WriteLine("Hangi programı çalıştırmak istersiniz? (1, 2 veya 3)");
                Console.WriteLine("1- Rastgele Sayı Bulma Oyunu");
                Console.WriteLine("2- Hesap Makinesi");
                Console.WriteLine("3- Ortalama Hesaplama");
                Console.WriteLine("Çıkmak için 0'a basın.");
                string choice = Console.ReadLine(); //readline ile konsola kullanıcıdan giriş yapmasını istiyorum.

                switch (choice) //kullanıcıdan seçim yapmasını istediğim için switch-case kullanıyorum.
                {
                    case "1":
                        RastgeleSayiBulmaOyunu();
                        break;
                    case "2":
                        HesapMakinesi();
                        break;
                    case "3":
                        OrtalamaHesaplama();
                        break;
                    case "0":
                        Console.WriteLine("Programdan çıkılıyor...");//eğer kullanıcı programdan çıkmak isterse 0a bamalı
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");//eğer kullanıcı 1-2-3-0 dışında bir sayı girerse uyarıyor.
                        break;
                }
                Console.WriteLine();
            }
        }

        static void RastgeleSayiBulmaOyunu()
        {
            Random random = new Random();//rastgele sayı tutmak için randomu kullandım
            int targetNumber = random.Next(1, 101);//1-100 arasında sayı tutmasını istedim
            int attempts = 5;//ve bu işlemi en fazla 5 kere yapabilsin dedim

            Console.WriteLine("1 ile 100 arasında bir sayı tuttum. Tahmin etmeye çalışın!");

            while (attempts > 0)//kullanıcının tahmin hakkı bitene kadar döngü devam etsin
            {
                Console.WriteLine($"Kalan tahmin hakkınız: {attempts}");
                Console.Write("Tahmininiz: ");
                int guess;
                bool isValid = int.TryParse(Console.ReadLine(), out guess);//kullanıcının girdiği değeri integera çevirip guess değişkenine atadım

                if (!isValid || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Lütfen 1 ile 100 arasında bir sayı girin.");
                    continue;
                }

                if (guess == targetNumber)
                {
                    Console.WriteLine("Tebrikler! Doğru tahmin ettiniz.");//doğru tahmin ederse döngüden çıkıyoruz
                    return;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Daha yüksek bir sayı deneyin.");//düşük tahmin ettiyse ipucu veriyoruz
                }
                else
                {
                    Console.WriteLine("Daha düşük bir sayı deneyin.");//yüksek tahmin ettiyse ipucu veriyoruz
                }

                attempts--;//her tahminde kullanıncıın hakkını bir azaltıyorum
            }

            Console.WriteLine("Üzgünüm, tahmin hakkınız bitti. Doğru sayı: " + targetNumber);//attemps değerim 0landığında kullanıcıya doğru sayıyı
        }

        static void HesapMakinesi()
        {
            Console.Write("İlk sayıyı girin: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci sayıyı girin: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Hangi işlemi yapmak istersiniz?");
            Console.WriteLine("Toplama için: +");
            Console.WriteLine("Çıkarma için: -");
            Console.WriteLine("Çarpma için: *");
            Console.WriteLine("Bölme için: /");
            string operation = Console.ReadLine();//kullanıcıdan işlem seçmesini istedim

            double result;//sonucu saklamak için bir değişken oluşturdum
            switch (operation)//switchcase ile kullanıcının seçtiği işleme göre işlem yapılmasını sağlıyorum
            {
                case "+":
                    result = num1 + num2;
                    Console.WriteLine("Sonuç: " + result);
                    break;
                case "-":
                    result = num1 - num2;
                    Console.WriteLine("Sonuç: " + result);
                    break;
                case "*":
                    result = num1 * num2;
                    Console.WriteLine("Sonuç: " + result);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Hata: Bir sayı sıfıra bölünemez.");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine("Sonuç: " + result);
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem seçimi.");//döngüyü sonlandırıyorum
                    break;
            }
        }

        static void OrtalamaHesaplama()
        {
            Console.Write("Birinci ders notunu girin (0-100): ");
            double not1 = NotuAl();

            Console.Write("İkinci ders notunu girin (0-100): ");
            double not2 = NotuAl();

            Console.Write("Üçüncü ders notunu girin (0-100): ");//kullanıcıdan 3 farklı ders notu istedim
            double not3 = NotuAl();

            double average = (not1 + not2 + not3) / 3; //notların ortalamasını alıyorum
            Console.WriteLine($"Ortalama: {average:F2}");//ortalama değerini 2 ondalıklı olarak yazdırıyorum

            Console.WriteLine("Harf Notu: " + HarfNotu(average));//harf notunu ekrana yazdırıyorum
        }

        static double NotuAl()
        {
            while (true) //geçerli not alana kadar döngü devam etsin
            {
                double not;
                bool isValid = double.TryParse(Console.ReadLine(), out not);

                if (isValid && not >= 0 && not <= 100) //not 0-100 aralıgında mı kontrol ediyorum
                {
                    return not;
                }
                else
                {
                    Console.WriteLine("Geçersiz not. Lütfen 0 ile 100 arasında bir sayı girin:");
                }
            }
        }

        static string HarfNotu(double average) //ortalama değerine göre harf notunu belirleyen fonksiyon
        {
            if (average >= 90) return "AA";
            if (average >= 85) return "BA";
            if (average >= 80) return "BB";
            if (average >= 75) return "CB";
            if (average >= 70) return "CC";
            if (average >= 65) return "DC";
            if (average >= 60) return "DD";
            if (average >= 50) return "FD";
            return "FF"; //eğer yukarıdakilerden de küçükse ff alsın yani kaldı demektir.
        }
    }
}