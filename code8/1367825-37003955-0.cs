    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                var timer = new Timer(test, null, 10000, 10000);
                Console.ReadLine();
                GC.KeepAlive(timer);
            }
            static void test(object obj)
            {
                if (stopwatch == null)
                    stopwatch = Stopwatch.StartNew();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            static Stopwatch stopwatch;
        }
    }
