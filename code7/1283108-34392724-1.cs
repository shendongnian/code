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
                var outputQueue = new BlockingCollection<int>(maxOutputQueueSize);
                var worker = Task.Run(() => output(outputQueue));
                var parallelWorkItems = 
                    workItems
                    .AsParallel()
                    .AsOrdered()
                    .WithDegreeOfParallelism(maxThreads)
                    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                    .Select(process);
                foreach (var item in parallelWorkItems)
                    outputQueue.Add(item);
                outputQueue.CompleteAdding();
                worker.Wait();
                Console.WriteLine("Done.");
            }
            static int process(int value) // Pretend that this compresses the data.
            {
                Console.WriteLine($"Worker {Thread.CurrentThread.ManagedThreadId} is processing {value}");
                Thread.Sleep(250);  // Simulate slow operation.
                return value; // Return updated work item.
            }
            static void output(BlockingCollection<int> queue)
            {
                foreach (var item in queue.GetConsumingEnumerable())
                    Console.WriteLine($"Output is processing {item}");
                Console.WriteLine("Finished outputting.");
            }
        }
    }
