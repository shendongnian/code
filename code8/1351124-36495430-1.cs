        static void Main(string[] args)
        {
            RunTasks();
        }
        // This sets up the parallel scheduler to use UP TO 16 simultaneous threads. In reality the thread
        // workload is managed by the CLR according to how many logical threads you have available on your
        // processor.
        private static readonly ParallelOptions _po = new ParallelOptions() { MaxDegreeOfParallelism = 16 };
        private static void RunTasks()
        {
            // Run 200 instances of PerformComputations in parallel. 
            Parallel.For(0, 200, _po, i => PerformComputations());
        }
        private static void PerformComputations()
        {
            // If you want to run the 500 iterations in parallel (sequence is not important),
            // use a concurrent collection. This needs absolutely no lock, the collection is
            // partitioned internally to avoid having to lock. Same goes if you need to share
            // data between multiple runs of PerformComputations(), declare a static bag at 
            // class level.
            var theBag = new ConcurrentBag<int>(Enumerable.Range(0, 500));
            Parallel.ForEach(theBag, _po, i =>
            {
                Console.WriteLine(i.ToString());
            });
            // Otherwise you don't need a lock at all anyway since each element here is treated
            // one at a time in sequence.
            var theList = Enumerable.Range(0, 500).ToList();
            foreach (var i in theList)
            {
                Console.WriteLine(i.ToString());
            }
        }
