    class Program
    {
        private static readonly object _lock = new object();
        private static readonly int numberOfItems = 1000000;
        private static readonly int _numberOfIterations = 1000000;
        private static void Main(string[] args)
        {
            MeasureTimeWithLocking();
            MeasureTimeWithCapuringContext();
            Console.WriteLine();
            MeasureTimeWithLocking();
            MeasureTimeWithCapuringContext();
            Console.WriteLine();
            MeasureTimeWithLocking();
            MeasureTimeWithCapuringContext();
            Console.ReadKey();
        }
        private static void MeasureTimeWithLocking()
        {
            List<ContextItem> items = new List<ContextItem>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfItems; i++)
            {
                ContextItem item = new ContextItem();
                item.Work1 = DoSomeWorkWithLock;
                item.Work2 = DoSomeWorkWithLock;
                item.Work3 = DoSomeWorkWithLock;
            }
            Parallel.ForEach(items, (item) =>
            {
                item.Work1(null);
                item.Work2(null);
                item.Work3(null);
            });
            stopwatch.Stop();
            Console.WriteLine("Time elapsed with locking:           " + stopwatch.Elapsed);
        }
        private static void MeasureTimeWithCapuringContext()
        {
            List<ContextItem> items = new List<ContextItem>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfItems; i++)
            {
                ContextItem item = new ContextItem();
                item.Context1 = ExecutionContext.Capture();
                item.Context2 = ExecutionContext.Capture();
                item.Context3 = ExecutionContext.Capture();
                item.Work1 = DoSomeWork;
                item.Work2 = DoSomeWork;
                item.Work3 = DoSomeWork;
            }
            foreach (ContextItem item in items)
            {
                ExecutionContext.Run(item.Context1, item.Work1, null);
                ExecutionContext.Run(item.Context2, item.Work2, null);
                ExecutionContext.Run(item.Context3, item.Work3, null);
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed with capturing context: " + stopwatch.Elapsed);
        }
        private static void DoSomeWork(object ignored)
        {
            Work();
        }
        private static void DoSomeWorkWithLock(object ignored)
        {
            lock (_lock)
            {
                Work();
            }
        }
        private static void Work()
        {
            int count = 0;
            for (int i = 0; i < _numberOfIterations; i++)
            {
                count ++;
            }
        }
        private class ContextItem
        {
            public ExecutionContext Context1 { get; set; }
            public ExecutionContext Context2 { get; set; }
            public ExecutionContext Context3 { get; set; }
            public ContextCallback Work1 { get; set; }
            public ContextCallback Work2 { get; set; }
            public ContextCallback Work3 { get; set; }
        }
    }
