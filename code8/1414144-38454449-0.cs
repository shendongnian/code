    public class Program
    {
        private static System.Timers.Timer aTimer;
    
        public static void Main()
        {
            aTimer = new System.Timers.Timer(5000); // interval in milliseconds (here - 5 seconds)
    
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent); // handler - what to do when 5 minutes elapsed
    
            aTimer.Enabled = true;
    
            // If the timer is declared in a long-running method, use
            // KeepAlive to prevent garbage collection from occurring
            // before the method ends.
            //GC.KeepAlive(aTimer);
        }
    
        //hadler
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string alarm = String.Format("Time check");
            seiyu.Speak(alarm);
            string sayTime = String.Format(DateTime.Now.ToString("h:mm tt"));
            seiyu.Speak(sayTime);
        }
    }
