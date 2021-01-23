    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace Demo
    {
        static class Program
        {
            const int PERIOD_MILLISECONDS = 10000;
            static void Main()
            {
                timer = new Timer(test, null, PERIOD_MILLISECONDS, PERIOD_MILLISECONDS);
                Console.ReadLine();
                GC.KeepAlive(timer);
            }
            static void test(object dummy)
            {
                if (stopwatch == null)
                    stopwatch = Stopwatch.StartNew();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                long newPeriod = PERIOD_MILLISECONDS - stopwatch.ElapsedMilliseconds + expectedElapsedMillseconds;
                timer.Change(newPeriod, PERIOD_MILLISECONDS);
                expectedElapsedMillseconds += PERIOD_MILLISECONDS;
            }
            static Stopwatch stopwatch;
            static long      expectedElapsedMillseconds;
            static Timer     timer;
        }
    }
