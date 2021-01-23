    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            stopwatch.Start();
            Todo();
            Thread.Sleep(4000);
            Todo();
        }
        public static void Todo()
        {
            if(stopwatch.Elapsed.TotalSeconds > 3)
            {
                // do stuff
                stopwatch.Restart();
            }
        }
    }
