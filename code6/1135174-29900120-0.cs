    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] cards = new string[] {
                    //http://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm
                    "378282246310005",  // American Express
                    "4012888888881881", // Visa
                    "6011111111111117", // Discover
                    "4222222222222", // Visa
                    "76009244561", // Dankort (PBS)
                    "5019717010103742", // Dakort (PBS) 
                    "6331101999990016", // Switch/Solo (Paymentech)
                    "30569309025904", // Diners Club 
                    //http://www.getcreditcardnumbers.com/
                    "5147004213414803", // Mastercard
                    "6011491706918120", // Discover
                    "379616680189541", // American Express
                    "4916111026621797", // Visa
                    //https://support.microsoft.com/en-us/kb/258255
                    "3111-1111-1111-1117", // American Express
                    "4111-1111-1111-1111", // Visa
                    "5111-1111-1111-1118", // Mastercard
                    "6111-1111-1111-1116" // Discover
                };
                foreach (string card in cards)
                {
                    Console.WriteLine(IsValid(card));
                }
                Console.ReadLine();
            }
            public static bool IsValid(object value)
            {
                if (value == null)
                {
                    return true;
                }
                string source = value as string;
                if (source == null)
                {
                    return false;
                }
                source = source.Replace("-", "").Replace(" ", "");
                int num = 0;
                bool flag = false;
                foreach (char ch in source.Reverse<char>())
                {
                    if ((ch < '0') || (ch > '9'))
                    {
                        return false;
                    }
                    int num2 = (ch - '0') * (flag ? 2 : 1);
                    flag = !flag;
                    while (num2 > 0)
                    {
                        num += num2 % 10;
                        num2 /= 10;
                    }
                }
                return ((num % 10) == 0);
            }
        }
    }
