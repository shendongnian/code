    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                Barrier barrier = new Barrier(5); // 5 == #participating threads.
                Action[] actions = new Action[10];
                var sw = Stopwatch.StartNew();
                ThreadPool.SetMinThreads(12, 12); // Prevent delay on starting threads.
                                                  // Not recommended for non-test code!
                for (int i = 0; i < actions.Length; ++i)
                    actions[i] = () => test(barrier, sw);
                Parallel.Invoke(actions);
            }
            static void test(Barrier barrier, Stopwatch sw)
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                Random rng = new Random(id);
                while (true)
                {
                    int wait = 5000 + rng.Next(5000);
                    Console.WriteLine($"[{sw.ElapsedMilliseconds:000000}] Thread {id} is sleeping for {wait} ms.");
                    Thread.Sleep(wait);
                    Console.WriteLine($"[{sw.ElapsedMilliseconds:000000}] Thread {id} is waiting at the barrier.");
                    barrier.SignalAndWait();
                    Console.WriteLine($"[{sw.ElapsedMilliseconds:000000}] Thread {id} passed the barrier.");
                    Thread.Sleep(1000); // This is the equivalent of your "Section A".
                }
            }
        }
    }
