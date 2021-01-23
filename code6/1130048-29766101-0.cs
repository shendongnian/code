    System.AggregateException: One or more errors occurred. ---> System.Threading.Ta
    sks.TaskCanceledException: A task was canceled.
       --- End of inner exception stack trace ---
       at System.Threading.Tasks.Task.WaitAll(Task[] tasks, Int32 millisecondsTimeou
    t, CancellationToken cancellationToken)
       at System.Threading.Tasks.Task.WaitAll(Task[] tasks, Int32 millisecondsTimeou
    t)
       at System.Threading.Tasks.Task.WaitAll(Task[] tasks)
       at bufferBlock.Program.Main(String[] args) in c:\dev\warmup\bufferBlock\buffe
    rBlock\Program.cs:line 49
    ---> (Inner Exception #0) System.Threading.Tasks.TaskCanceledException: A task w
    as canceled.<---
    
    0
    1
    2
    3
    4
    5
        private static async Task Produce(BufferBlock<int> queue, IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                await queue.SendAsync(value);
            }
            queue.Complete();
        }
        private static async Task<IEnumerable<int>> Consume(BufferBlock<int> queue)
        {
            var ret = new List<int>();
            while (await queue.OutputAvailableAsync())
            {
                ret.Add(await queue.ReceiveAsync());
            }
            return ret;
        }
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var queue = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 5, CancellationToken = cts.Token });
            // Start the producer and consumer.
            var values = Enumerable.Range(0, 10);
            Produce(queue, values);
            var consumer = Consume(queue);
            cts.Cancel();
            try
            {
                Task.WaitAll(consumer, queue.Completion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            foreach (var i in consumer.Result)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
