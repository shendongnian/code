    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
                    num = num + GetSumOfDigits(i);
                Console.WriteLine("Serial took: " + sw.Elapsed);
                Console.WriteLine(num);
                sw.Restart();
                num = 0;
                var rangePartitioner = Partitioner.Create(0, n + 1);
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    long subtotal = 0;
                    for (long i = range.Item1; i < range.Item2; i++)
                        subtotal += GetSumOfDigits(i);
                    Interlocked.Add(ref num, subtotal);
                });
                Console.WriteLine("Parallel took: " + sw.Elapsed);
                Console.WriteLine(num);
                sw.Restart();
                num = Enumerable.Range(1, 123456789).AsParallel().Select(i => GetSumOfDigits(i)).Sum();
                Console.WriteLine("Linq took: " + sw.Elapsed);
                Console.WriteLine(num);
                sw.Restart();
                initSums();
                num = 0;
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    long subtotal = 0;
                    for (long i = range.Item1; i < range.Item2; i++)
                        subtotal += FastGetSumOfDigits(i);
                    Interlocked.Add(ref num, subtotal);
                });
                Console.WriteLine("Fast Parallel took: " + sw.Elapsed);
                Console.WriteLine(num);
            }
            private static void initSums()
            {
                for (int i = 0; i < SUMS_SIZE; ++i)
                    sums[i] = (short)GetSumOfDigits(i);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static long GetSumOfDigits(long n)
            {
                long sum = 0;
                while (n != 0)
                {
                    sum += n%10;
                    n /= 10;
                }
                return sum;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static long FastGetSumOfDigits(long n)
            {
                long sum = 0;
                while (n != 0)
                {
                    sum += sums[n % SUMS_SIZE];
                    n /= SUMS_SIZE;
                }
                return sum;
            }
            static short[] sums = new short[SUMS_SIZE];
            private const int SUMS_SIZE = 1000;
        }
    }
