    public class ViewModel{
        private static System.Timers.Timer aTimer;
        public ViewModel()
        {
            aTimer = new Timer();
            aTimer.Interval = 2000; // every two seconds
            // Hookup to the elapsed event
            aTimer.Elapsed += DoWork;
      
            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;
            // Start the timer
            aTimer.Enabled = true;
        }
        public void DoWork(Object source, System.Timers.ElapsedEventArgs e) { 
            //do work here
        }
    }
