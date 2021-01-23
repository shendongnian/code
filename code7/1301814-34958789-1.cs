        static ManualResetEvent timerFired = new ManualResetEvent(false);
   
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Interval = 5000; // 5 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            Console.ReadKey();
            // This call will return only after timerFired.Set() is
            // called.  So, if the user hits a key before the timer is
            // fired, this will block for a little bit, until the timer fires.  
            // Otherwise, it will return immediately
            timerFired.WaitOne();
        }
    
        public static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Timer Fired.");
            timerFired.Set();
        }
