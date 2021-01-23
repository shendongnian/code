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
                var signal    = new EventSignaller();
                var countdown = new CountdownEvent(numWorkers);
                for (int i = 0; i < numWorkers; ++i)
                {
                    int n = i; // Prevent modified closure.
                    Task.Run(() => worker(signal, countdown, n));
                }
                print("Main thread is waiting for a five seconds.");
                Thread.Sleep(5000);
                print("Main thread is signalling all the workers to start.");
                signal.Signal();
                print("Main thread is waiting for all the workers to finish.");
                countdown.Wait();
                print("Main thread finished waiting for all the workers to complete.");
            }
            static void worker(EventSignaller signal, CountdownEvent countdown, int workerNumber)
            {
                print($"Worker {workerNumber} is waiting for signal.");
                signal.Wait();
                int delay = randomDelayMilliseconds();
                print($"Worker {workerNumber} got signal, now sleeping for {delay}");
                Thread.Sleep(delay);
                print($"Worker {workerNumber} finished work.");
                countdown.Signal();
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
        public sealed class EventSignaller
        {
            public void Signal()
            {
                lock (_lock)
                {
                    Monitor.PulseAll(_lock);
                }
            }
            public void Wait()
            {
                lock (_lock)
                {
                    Monitor.Wait(_lock);
                }
            }
            public bool Wait(int timeoutMilliseconds)
            {
                lock (_lock)
                {
                    return Monitor.Wait(_lock, timeoutMilliseconds);
                }
            }
            readonly object _lock = new object();
        }
    }
