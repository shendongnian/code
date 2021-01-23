    class Program
    {
        public static void ProcessFiles(CancellationToken cts)
        {            
            try
            {                
                //LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(2);
                TaskScheduler ts = TaskScheduler.Default;
                List<Task> tasks = new List<Task>();
                TaskFactory factory = new TaskFactory(ts);                
                for (int i = 0; i < 1000; i++)
                {
                    int i1 = i;
                    var t = factory.StartNew(() =>
                    {
                        Console.WriteLine(cts.IsCancellationRequested);
                        if (cts != null) Console.WriteLine("{0} --- {1}", i1, GetGuid(cts));
                    }, cts);
                    tasks.Add(t);
                }
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("\n\nSuccessful completion.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(cts.IsCancellationRequested);
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task.Factory.StartNew(() => { Thread.Sleep(10000); cts.Cancel(); });
            ProcessFiles(cts.Token);
            Console.ReadKey();
        }
        private static Guid GetGuid(CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
            {
                return Guid.Empty;
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return Guid.NewGuid();
        }
    }
