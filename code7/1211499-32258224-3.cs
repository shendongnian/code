    class PerfTestHarness
    {
        private List<string> corpus;
        public PerfTestHarness( List<string> corpus )
        {
            this.corpus = corpus;
            // Warm up the JIT
            // Note that `result` is discarded. We reference it via 'result[0]' as an 
            // unused paramater to my prints to be absolutely sure it doesn't get 
            // optimized out. Cheap hack, but it works.
            string result;
            result = FastConcat.Concat( this.corpus );
            Console.WriteLine( "Fast warmup done", result[0] );
            result = string.Concat( this.corpus.ToArray() );
            Console.WriteLine( "Safe warmup done", result[0] );
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void PerfTestSafe()
        {
            Stopwatch watch = new Stopwatch();
            string result;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
            result = string.Concat( this.corpus.ToArray() );
            watch.Stop();
            Console.WriteLine( "Safe Time: {0:0.000} ms", watch.Elapsed.TotalMilliseconds, result[0] );
            Console.WriteLine( "Memory usage: {0:0.000} MB", Environment.WorkingSet / 1000000.0 );
            Console.WriteLine();
        }
        public void PerfTestUnsafe()
        {
            Stopwatch watch = new Stopwatch();
            string result;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            watch.Start();
            result = FastConcat.Concat( this.corpus );
            watch.Stop();
            Console.WriteLine( "Unsafe Time: {0:0.000} ms", watch.Elapsed.TotalMilliseconds, result[0] );
            Console.WriteLine( "Memory usage: {0:0.000} MB", Environment.WorkingSet / 1000000.0 );
            Console.WriteLine();
        }
    }
