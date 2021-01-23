    using System;
    using System.Linq;
    using System.Threading;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                int maxThreads = 4;
                var workItems = Enumerable.Range(1, 100);
                var parallelWorkItems = workItems.AsParallel().WithDegreeOfParallelism(maxThreads);
                parallelWorkItems.ForAll(worker);
            }
            static void worker(int value)
            {
                Console.WriteLine($"Worker {Thread.CurrentThread.ManagedThreadId} is processing {value}");
                Thread.Sleep(1000); // Simulate work.
            }
        }
    }
