    using System;
    using System.Numerics;
    
    namespace Vouchers
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter voucher number: ");
                BigInteger input = BigInteger.Parse(Console.ReadLine());
                for (BigInteger i = 0;i<10000000;i++)
                {
                    BigInteger testValue = (23 * i * i * i * i + 19 * i * i * i + 5 * i * i + 29 * i + 3) % 65537;
                    if(testValue==input)
                    {
                        Console.WriteLine("That is voucher # " + i.ToString());
                        break;
                    }
                    if (i == 100) Console.WriteLine(testValue);
                }
                Console.ReadKey();
            }
        }
    }
