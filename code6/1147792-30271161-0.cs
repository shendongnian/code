    class Program
    {
        static void Main(string[] args)
        {
            // Timer interval in ms
            // in your case read from database
            double timerIntervalInMs = 1000.00;
            var myTimer = new Timer(timerIntervalInMs);
            // I generally prefer to use AutoReset false 
            // and explicitly start the timer within the elapsed event.
            // Thus you can ensure that there will not be overlapping elapsed events.
            myTimer.AutoReset = false;
            myTimer.Elapsed += OnMyTimedEvent;
            myTimer.Enabled = true;
            myTimer.Start();
            Console.ReadLine();
        }
        private static void OnMyTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("On timer event");
            // Do work
            var timerObj = (Timer) source;
            timerObj.Start();
        }
    }
