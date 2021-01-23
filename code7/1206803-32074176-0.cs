    class Program
    {
        static void Main(string[] args)
        {
            OutputNumbersWithDataflow();
            OutputNumbersWithParallelLinq();
            Console.ReadLine();
        }
        private static async Task HandleStringAsync(string s)
        {
            await Task.Delay(200);
            Console.WriteLine("Handled {0}.", s);
        }
        private static void OutputNumbersWithDataflow()
        {
            var block = new ActionBlock<string>(
                HandleStringAsync,
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded });
            for (int i = 0; i < 20; i++)
            {
                block.Post(i.ToString());
            }
            block.Complete();
            block.Completion.Wait();
        }
        private static string HandleString(string s)
        {
            // Perform some computation on s...
            Thread.Sleep(200);
            return s;
        }
        private static void OutputNumbersWithParallelLinq()
        {
            var myNumbers = Enumerable.Range(0, 20).AsParallel()
                                                   .AsOrdered()
                                                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                                   .WithMergeOptions(ParallelMergeOptions.NotBuffered);
            var processed = from i in myNumbers
                            select HandleString(i.ToString());
            foreach (var s in processed)
            {
                Console.WriteLine(s);
            }
        }
    }
