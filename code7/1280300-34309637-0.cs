     private static System.Timers.Timer aTimer;
     private static int counter = 0;
     private static void SetTimer()
    {
        // Create a timer with a one minute interval.
        aTimer = new System.Timers.Timer(60000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
      private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        //Increment the counter
         counter++;
         if (counter== 60)
         {
            // One hour has passed
            // Reset the counter and create your file
            counter = 0;
            CreateFile();
         }
    }
