
//--AtmApp--

using System.ComponentModel;
using System.Globalization;
using System.Transactions;

string password;
int balance = 10000;
double foreignCurreny;
 //Kullanıcı Şifresi 1907'dir
    Console.WriteLine("Şifrenizi Giriniz: ");
    password = Console.ReadLine();

    while (password == "1907")
    {
    back:
        int select;
        Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz");
        Console.WriteLine("Para Çekmek İçin 1'e Basınız");
        Console.WriteLine("Para Yatırmak İçin 2'ye Basınız");
        Console.WriteLine("Kredi Kullanmak İçin 3'e Basınız");
        Console.WriteLine("Döviz İşlemleri İçin 4'e Basınız");
        Console.WriteLine("Vadeli Hesaplar İçin 5'e Basınız");
        Console.WriteLine("Çıkış İçin 0'a Basınız");

        select = Convert.ToInt32(Console.ReadLine());
        if (select == 1)
        {
            int cTutar;
            Console.WriteLine("Çekmek İstediğiniz Tutarı Giriniz: ");
            cTutar = Convert.ToInt32(Console.ReadLine());
            if (cTutar > balance)
            {
                Console.WriteLine("Yetersiz Bakiye");
                Console.WriteLine(balance);
            }
            else
            {
                Console.WriteLine("Bakiyeniz: " + (balance - cTutar));
            }
        }
        else if (select == 2)
        {
            int yTutar;
            Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz: ");
            yTutar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bakiyeniz: " + (balance + yTutar));
        }
        else if (select == 3)
        {
            int cost = 49;
            int creditBalance;
            int creditAmout;
            int creditMonth;
            Console.WriteLine("Kullanmak İstediğiniz Kredi Tutarını Giriniz: ");
            creditAmout = Convert.ToInt32(Console.ReadLine());
            if (creditAmout <= 999)
            {
                Console.WriteLine("Kredi Tutarı 1.000 Tlden Az Olamaz!");
            }
            Console.WriteLine("Vade Seçeneğini Giriniz: ");
            creditMonth = Convert.ToInt32(Console.ReadLine());
            if (creditMonth < 3)
            {
                Console.WriteLine("Taksit Seçeneği 3'ün Altında Olamaz!");

            }

            else if (creditAmout >= 10000 && (creditMonth >= 3 || creditMonth < 12))

            {
                int interest;
                balance = balance + creditAmout;
                interest = (int)(creditAmout / 100 * 2.75);
                creditBalance = interest + creditAmout + cost;
                Console.WriteLine("Bakiyeniz: " + balance);
                Console.WriteLine("Kredi Borcunuz: " + creditBalance);
            }
            else if (creditAmout >= 10000 && creditMonth >= 12)
            {
                int interest;
                balance = balance + creditAmout;
                interest = (int)(creditAmout / 100 * 2.99);
                creditBalance = interest + creditAmout + cost;
                Console.WriteLine("Bakiyeniz: " + balance);
                Console.WriteLine("Kredi Borcunuz: " + creditBalance);
            }
            else if ((creditAmout >= 1000 || creditAmout <= 10000) && (creditMonth >= 3 || creditMonth < 12))

            {
                int interest;
                balance = balance + creditAmout;
                interest = (int)(creditAmout / 100 * 1.63);
                creditBalance = interest + creditAmout + cost;
                Console.WriteLine("Bakiyeniz: " + balance);
                Console.WriteLine("Kredi Borcunuz: " + creditBalance);
            }
            else if ((creditAmout >= 1000 || creditAmout <= 10000) && creditMonth > 12)

            {
                int interest;
                balance = balance + creditAmout;
                interest = (int)(creditAmout / 100 * 1.99);
                creditBalance = interest + creditAmout + cost;
                Console.WriteLine("Bakiyeniz: " + balance);
                Console.WriteLine("Kredi Borcunuz: " + creditBalance);
            }
        }
        else if (select == 4)
        {
            int currencyTransaction;
            Console.WriteLine("Dolar İşlemi İçin 1'e Basınız");
            Console.WriteLine("Euro İşlemi İçin 2'ye Basınız");
            currencyTransaction = Convert.ToInt32(Console.ReadLine());

            if (currencyTransaction == 1)
            {
                int currencyAmount;
                string currencySelect;
                Console.WriteLine("Dolar Kuru 14.37 Türk Lirası Onaylıyor musunuz? : Evet/Hayır");
                currencySelect = Console.ReadLine();
                if (currencySelect == "Evet")
                {
                    Console.WriteLine("Tutar Giriniz : ");
                    currencyAmount = Convert.ToInt32(Console.ReadLine());
                    balance = balance - currencyAmount;
                    foreignCurreny = balance / 14.37;
                    Console.WriteLine("Yeni Dolar Bakiyeniz : " + foreignCurreny + "$");
                    Console.WriteLine("Kalan TL Bakiyeniz : " + balance);
                }
                else if (currencySelect == "Hayır")
                {
                    goto back;
                }
            }
            else if (currencyTransaction == 2)
            {
                int currencyAmount;
                string currencySelect;
                Console.WriteLine("Euro Kuru 15.03 Türk Lirası Onaylıyor musunuz? : Evet/Hayır");
                currencySelect = Console.ReadLine();

                if (currencySelect == "Evet")
                {
                    Console.WriteLine("Tutar Giriniz : ");
                    currencyAmount = Convert.ToInt32(Console.ReadLine());
                    balance = balance - currencyAmount;
                    foreignCurreny = balance / 15.03;
                    Console.WriteLine("Yeni Dolar Bakiyeniz : " + foreignCurreny + "$");
                    Console.WriteLine("Kalan TL Bakiyeniz : " + balance);
                }
                else if (currencySelect == "Hayır")
                {
                    goto back;
                }
            }

        }
        else if (select == 5)
        {
            int depositBalance;
            int depositAccount;
            Console.WriteLine("3 Ay Vade = %10 ----- Onaylıyor Musunuz => 3");
            Console.WriteLine("6 Ay Vade = %11.50 ----- Onaylıyor Musunuz => 6");
            Console.WriteLine("9 Ay Vade = %12.25 ----- Onaylıyor Musunuz => 9");
            Console.WriteLine("12 Ay Vade = %13.10 ----- Onaylıyor Musunuz => 12");
            int depositSelect = Convert.ToInt32(Console.ReadLine());

            if (depositSelect == 3)
            {
                Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz: ");
                depositBalance = Convert.ToInt32(Console.ReadLine());
                balance = balance - depositBalance;
                depositAccount = (int)((depositBalance * 0.10) + depositBalance);
                Console.WriteLine("Bakiyeniz: " + balance + "Vadeli Bakiyeniz: " + depositAccount);
            }
            else if (depositSelect == 6)
            {
                Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz: ");
                depositBalance = Convert.ToInt32(Console.ReadLine());
                balance = balance - depositBalance;
                depositAccount = (int)((depositBalance / 100 * 11.25) + depositBalance);
                Console.WriteLine("Bakiyeniz: " + balance + "Vadeli Bakiyeniz: " + depositAccount);
            }
            else if (depositSelect == 9)
            {
                Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz: ");
                depositBalance = Convert.ToInt32(Console.ReadLine());
                balance = balance - depositBalance;
                depositAccount = (int)((depositBalance / 100 * 12.25) + depositBalance);
                Console.WriteLine("Bakiyeniz: " + balance + "Vadeli Bakiyeniz: " + depositAccount);
            }
            else if (depositSelect == 12)
            {
                Console.WriteLine("Yatırmak İstediğiniz Tutarı Giriniz: ");
                depositBalance = Convert.ToInt32(Console.ReadLine());
                balance = balance - depositBalance;
                depositAccount = (int)((depositBalance / 100 * 13.10) + depositBalance);
                Console.WriteLine("Bakiyeniz: " + balance + "Vadeli Bakiyeniz: " + depositAccount);
            }
        }
        else if (select == 0)
        {
            Environment.Exit(0);
        }
    }
Console.WriteLine("Şifreniz Yanlıştır!");
Console.ReadLine();