    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            static SpinLock locker = new SpinLock(enableThreadOwnerTracking:true);
            static void Main()
            {
                var task1 = Task.Run(() => test(0)); // Change to test(1) to test re-entrant protection.
                var task2 = Task.Run(() => test(0));
                Console.WriteLine("Started threads. Waiting for them to exit.");
                Task.WaitAll(task1, task2);
                Console.WriteLine("Waited for threads to exit.");
                Console.ReadLine();
            }
            static void test(int n)
            {
                bool lockTaken = false;
                try
                {
                    locker.TryEnter(0, ref lockTaken);
                    if (lockTaken)
                    {
                        if (n > 0)
                            test(n - 1);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Throwing exception");
                        throw new InvalidOperationException("Error: Multithreaded access to test() detected");
                    }
                }
                finally
                {
                    if (lockTaken)
                        locker.Exit();
                }
            }
        }
    }
