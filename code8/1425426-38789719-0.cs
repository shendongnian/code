     using System.Timers;
     static void Main(string[] args)
        {
            Timer tmr = new Timer();
            int seconds = 15; // Not needed, only for demonstration purposes
            tmr.Interval = 1000 * (seconds); // Interval - how long will it take for the timer to elapse. (In milliseconds)
            tmr.Elapsed += Tmr_Elapsed; // Subscribe to the event
            tmr.Start(); // Run the timer
        }
        private static void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Stop the video
        }
