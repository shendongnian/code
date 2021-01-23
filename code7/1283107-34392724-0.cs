    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                int maxThreads = 4;
                int maxOutputQueueSize = 10;
                var workItems = Enumerable.Range(1, 100); // Pretend these are your files
                var parallelWorkItems = 
                    workItems
                    .AsParallel()
                    .AsOrdered()
                    .WithDegreeOfParallelism(maxThreads);
                var outputQueue = new BlockingCollection<int>(maxOutputQueueSize);
                Task.Run(() => output(outputQueue));
                parallelWorkItems.ForAll(item => worker(item, outputQueue));
                outputQueue.CompleteAdding();
                Console.ReadLine();
            }
            static void worker(int value, BlockingCollection<int> queue) // Pretend that this compresses the data.
            {
                Console.WriteLine($"Worker {Thread.CurrentThread.ManagedThreadId} is processing {value}");
                Thread.Sleep(1000); // Simulate slow operation.
                queue.Add(value);
            }
            static void output(BlockingCollection<int> queue)
            {
                foreach (var item in queue.GetConsumingEnumerable())
                    Console.WriteLine($"Output is processing {item}");
                Console.WriteLine("Finished outputting.");
            }
        }
    }
