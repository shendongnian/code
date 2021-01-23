    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConcurrentBagTest
    {
        // You must compile this for x64 or you will get OutOfMemory exception
        class Program
        {
            static void Main(string[] args)
            {
                ListTest(10000000);
                ListTest(100000000);
                ListTest(1000000000);
                ConcurrentBagTest(10000000);
                ConcurrentBagTest(100000000);
                Console.ReadKey();
            }
            static void ConcurrentBagTest(long count)
            {
                try
                {
                    var bag = new ConcurrentBag<long>();
                    Console.WriteLine($"--- ConcurrentBagTest count = {count}");
                    Console.WriteLine($"I will use {(count * sizeof(long)) / Math.Pow(1024, 2)} MiB of RAM");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (long i = 0; i < count; i++)
                    {
                        bag.Add(i);
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"Inserted {bag.LongCount()} items in {stopwatch.Elapsed.TotalSeconds} s");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            static void ListTest(long count)
            {
                try
                {
                    var list = new List<long>();
                    Console.WriteLine($"--- ListTest count = {count}");
                    Console.WriteLine($"I will use {(count * sizeof(long)) / Math.Pow(1024, 2)} MiB of RAM");
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (long i = 0; i < count; i++)
                    {
                        list.Add(i);
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"Inserted {list.LongCount()} items in {stopwatch.Elapsed.TotalSeconds} s");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
