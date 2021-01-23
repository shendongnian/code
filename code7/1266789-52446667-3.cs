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
                DateTime date = DateTime.Now;
                ulong ulong_a;
                ulong ulong_b;
                if (decimal_number <= ulong.MaxValue)
                {
                    ulong ulong_number = Convert.ToUInt64(decimal_number);
                    if (ulong_number < 2)
                    {
                        Console.WriteLine(ulong_number + " is not a prime number");
                    }
                    else if (ulong_number == 2 || ulong_number == 3)
                    {
                        Console.WriteLine(ulong_number + " is a prime number");
                    }
                    else if (ulong_number % 2 == 0)
                    {
                        Console.WriteLine(ulong_number + " is not a prime number and is divisible by 2");
                    }
                    else
                    {
                        ulong_a = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(ulong_number)));
                        for (ulong_b = 3; ulong_b <= ulong_a; ulong_b += 2)
                        {
                            if (ulong_number % ulong_b == 0)
                            {
                                Console.WriteLine(ulong_number + " is not a prime number and is divisible by " + ulong_b);
                                goto terminate_ulong_primality_test;
                            }
                        }
                        Console.WriteLine(ulong_number + " is a prime number");
                    }
                    terminate_ulong_primality_test:
                    {
                    }
                }
                else
                {
                    if (decimal_number % 2 == 0)
                    {
                        Console.WriteLine(decimal_number + " is not a prime number and is divisible by 2");
                    }
                    else
                    {
                        ulong_a = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(ulong.MaxValue) * Math.Sqrt(Convert.ToDouble(decimal_number / ulong.MaxValue))));
                        for (ulong_b = 3; ulong_b <= ulong_a; ulong_b += 2)
                        {
                            if (decimal_number % ulong_b == 0)
                            {
                                Console.WriteLine(decimal_number + " is not a prime number and is divisible by " + ulong_b);
                                goto terminate_decimal_primality_test;
                            }
                        }
                        Console.WriteLine(decimal_number + " is a prime number");
                    }
                    terminate_decimal_primality_test:
                    {
                    }
                }
                Console.WriteLine("elapsed time: " + (DateTime.Now - date));
                Console.ReadKey();
            }
        }
    }
