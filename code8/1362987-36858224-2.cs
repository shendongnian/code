    class Program {
        static System.Timers.Timer aTimer;
        static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        static TimeSpan LongToRun = new TimeSpan(0,5,0); //run for 5 minutes
        static void Main (string[] args)    {
            Console.WriteLine("Start Of Program" + DateTime.Now);
            Thread.Sleep(120000); //sleep for 2 mins
            sw.Reset();
            sw.Start();
            Start();
        }
        static void Start() {
            TimeSpan ts = sw.Elapsed;
            while (ts.TotalSeconds < LongToRun.TotalSeconds) {
                doWork();
                Thread.Sleep(60000);
                ts = sw.Elapsed;
            }
            Console.WriteLine("End of program");
            Console.ReadLine();
        }
        static void doWork() {
             Console.WriteLine(DateTime.Now);
        }
    }  
