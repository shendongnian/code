    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Stopwatch t0 = new Stopwatch();
                int maxNumber = 20;
                
                long start;
                t0.Start();
                start = Orig(maxNumber);
                t0.Stop();
    
                Console.WriteLine("Original | {0:d}, {1:d}", maxNumber, start);
                // Original | 20, 232792560
                Console.WriteLine("Original | time elapsed = {0}.", t0.Elapsed);
                // Original | time elapsed = 00:00:02.0585575
    
                t0.Restart();
                start = Test(maxNumber);
                t0.Stop();
    
                Console.WriteLine("Test | {0:d}, {1:d}", maxNumber, start);
                // Test | 20, 232792560
                Console.WriteLine("Test | time elapsed = {0}.", t0.Elapsed);
                // Test | time elapsed = 00:00:00.0002763
                
                Console.ReadLine();
            }
    
            public static long Orig(int maxNumber)
            {
                bool found = false;
                long start = 0;
                while (!found)
                {
                    start += maxNumber;
                    found = true;
                    for (int i=2; i < 21; i++)
                    {
                        if (start % i != 0)
                            found = false;
                    }
                }
                return start;
            }
    
            public static long Test(int maxNumber)
            {
                long result = 1;
    
                for (long i = 2; i <= maxNumber; i++)
                {
                    result = (result * i) / GCD(result, i);
                }
    
                return result;
            }
    
            public static long GCD(long a, long b)
            {
                while (b != 0)
                {
                    long c = b;
                    b = a % b;
                    a = c;
                }
    
                return a;
            }
        }
    }
