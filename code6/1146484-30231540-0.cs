        System.Timers.Timer timer = new System.Timers.Timer();
        TimeSpan tsDifference = DateTime.Parse("06:00 pm").Subtract(DateTime.Now);
        timer.Interval= (double)((tsDifference.Hours * 60 * 60) + (tsDifference.Minutes * 60) + (tsDifference.Seconds)) * 1000 + (tsDifference.Milliseconds);    
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        timer.Enabled=true;
    
          void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
                {
                   //turn off your monitor
                 }
