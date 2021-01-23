        private static System.Timers.Timer MyTimer;
        static bool runningloop;
        public static void Main()
        {
            runningloop=true;
            MyTimer = new System.Timers.Timer();
            MyTimer.Interval = 2000;
            MyTimer.Elapsed += OnTimedEvent;
            MyTimer.Enabled = true;
    
            // If the timer is declared in a long-running method, use KeepAlive to prevent garbage collection
            // from occurring before the method ends. 
            //GC.KeepAlive(MyTimer) 
    
            while(runningloop)
            {
              //do your work here
            }
        }
    
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            runningloop=false;
        }
