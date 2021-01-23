    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace SimpleTPL
    {
        class MyObj
        {
            public MyObj(string data)
            {
                Data = data;
            }
            public readonly string Data;
        }
        class Program
        {
            static void Main()
            {
                var queue = new ActionBlock<MyObj>(data => process(data), actionBlockOptions());
                var task = queueData(queue);
                Console.WriteLine("Waiting for task to complete.");
                task.Wait();
                Console.WriteLine("Completed.");
            }
            private static void process(MyObj data)
            {
                Console.WriteLine("Processing data " + data.Data);
                Thread.Sleep(200); // Simulate load.
            }
            private static async Task queueData(ActionBlock<MyObj> executor)
            {
                for (int i = 0; i < 20; ++i)
                {
                    Console.WriteLine("Queuing data " + i);
                    MyObj data = new MyObj(i.ToString());
                    await executor.SendAsync(data);
                }
                Console.WriteLine("Indicating that no more data will be queued.");
                executor.Complete(); // Indicate that no more items will be queued.
                Console.WriteLine("Waiting for queue to empty.");
                await executor.Completion; // Wait for executor queue to empty.
            }
            private static ExecutionDataflowBlockOptions actionBlockOptions()
            {
                return new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 4,
                    BoundedCapacity        = 8
                };
            }
        }
    }
