    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                test().Wait();
            }
            static async Task test()
            {
                string filename = @"Your test filename goes here";
                await Task.Run(async () => await processFile(filename));
            }
            static async Task processFile(string filename)
            {
                var options = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8, BoundedCapacity = 100 };
                var action = new ActionBlock<string>(s => process(s), options);
                foreach (var line in File.ReadLines(filename))
                    await action.SendAsync(line);
                action.Complete();
                await action.Completion;
            }
            static void process(string line)
            {
                Thread.Sleep(100);  // Simulate work.
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + line);
            }
        }
    }
