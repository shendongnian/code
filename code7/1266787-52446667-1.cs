    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace PrimalityTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter a number: ");
                decimal decimal_number = Convert.ToDecimal(Console.ReadLine());
                ulong ulong_a;
                ulong ulong_b;
                if (decimal_number <= ulong.MaxValue)
                {
                    ulong ulong_number = Convert.ToUInt64(decimal_number);
                    ulong_a = Convert.ToUInt64(Math.Round(Math.Sqrt(ulong_number))) + 1;
                    if (ulong_number == 1 || ulong_number == 0)
                    {
                        Console.WriteLine(ulong_number + " is not a prime number");
                    }
                    else
                    {
                        for (ulong_b = 2; ulong_b <= ulong_a; ulong_b++)
                        {
                            if (ulong_number % ulong_b == 0 && ulong_a != ulong_b)
                            {
                                Console.WriteLine(ulong_number + " is not a prime number and is divisible by " + ulong_b);
                                break;
                            }
                            else if (ulong_a == ulong_b)
                            {
                                Console.WriteLine(ulong_number + " is a prime number");
                                break;
                            }
                        }
                    }
                }
                if (decimal_number > ulong.MaxValue)
                {
                    ulong_a = Convert.ToUInt64(Math.Round(Math.Sqrt(ulong.MaxValue) * Math.Sqrt(Convert.ToDouble(decimal_number / ulong.MaxValue)))) + 1;
                    for (ulong_b = 2; ulong_b <= ulong_a; ulong_b++)
                    {
                        if (decimal_number % ulong_b == 0 && ulong_a != ulong_b)
                        {
                            Console.WriteLine(decimal_number + " is not a prime number and is divisible by " + ulong_b);
                            break;
                        }
                        else if (ulong_a == ulong_b)
                        {
                            Console.WriteLine(decimal_number + " is a prime number");
                            break;
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
