    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                print("Main thread is starting the workers.");
                int numWorkers = 10;
                var barrier = new Barrier(numWorkers + 1); // Workers + main (controlling) thread.
                for (int i = 0; i < numWorkers; ++i)
                {
                    int n = i; // Prevent modified closure.
                    Task.Run(() => worker(barrier, n));
                }
                while (true)
                {
                    print("***************** Press <RETURN> to signal the workers to start");
                    Console.ReadLine();
                    print("Main thread is signalling all the workers to start.");
                    // This will wait for all the workers to issue their call to
                    // barrier.SignalAndWait() before it returns:
                    barrier.SignalAndWait(); 
                    // At this point, all workers AND the main thread are at the same point.
                }
            }
            static void worker(Barrier barrier, int workerNumber)
            {
                int iter = 0;
                while (true)
                {
                    print($"Worker {workerNumber} on iteration {iter} is waiting for barrier.");
                    // This will wait for all the other workers AND the main thread 
                    // to issue their call to barrier.SignalAndWait() before it returns:
                    barrier.SignalAndWait();
                    // At this point, all workers AND the main thread are at the same point.
                    int delay = randomDelayMilliseconds();
                    print($"Worker {workerNumber} got barrier, now sleeping for {delay}");
                    Thread.Sleep(delay);
                    print($"Worker {workerNumber} finished work for iteration {iter}.");
                }
            }
            static void print(string message)
            {
                Console.WriteLine($"[{sw.ElapsedMilliseconds:00000}] {message}");
            }
            static int randomDelayMilliseconds()
            {
                lock (rng)
                {
                    return rng.Next(10000) + 5000;
                }
            }
            static Random    rng = new Random();
            static Stopwatch sw  = Stopwatch.StartNew();
        }
    }
