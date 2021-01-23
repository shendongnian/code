        private static async Task Produce(
            BufferBlock<int> queue, 
            IEnumerable<int> values,
            CancellationToken token
            )
        {
            foreach (var value in values)
            {
                await queue.SendAsync(value, token);
                Console.WriteLine(value);
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
            var values = Enumerable.Range(0, 100);
            Produce(queue, values, cts.Token);
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
