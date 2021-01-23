    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            public static void Main()
            {
                long n = 123456789;
                Stopwatch sw = Stopwatch.StartNew();
                long num = 0;
                for (long i = 0; i <= n; i++)
                {
                    num = num + GetSumOfDigits(i);
                }
                Console.WriteLine("Serial took: " + sw.Elapsed);
                Console.WriteLine(num);
                sw.Restart();
                num = 0;
                var rangePartitioner = Partitioner.Create(0, n+1);
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    long subtotal = 0;
                    for (long i = range.Item1; i < range.Item2; i++)
                        subtotal += GetSumOfDigits(i);
                    Interlocked.Add(ref num, subtotal);
                });
                Console.WriteLine("Parallel took: " + sw.Elapsed);
                Console.WriteLine(num);
            }
            static long GetSumOfDigits(long n)
            {
                long num2 = 0;
                long num3 = n;
                while (num3 != 0)
                {
                    var r = num3 % 10;
                    num3 = num3 / 10;
                    num2 = num2 + r;
                }
                return num2;
            }
        }
    }
