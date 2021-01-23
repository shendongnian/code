    class Program
    {
        private static System.Timers.Timer _timer;
        static void Main(string[] args)
        {
            _timer = new System.Timers.Timer(2000);
            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
            Console.ReadLine();
        }
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop(); //If you only want it to run once
            Console.WriteLine("Elapsed");
        }
    }
