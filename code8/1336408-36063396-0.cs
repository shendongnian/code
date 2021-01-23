        //defined globally
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
         //api call goes here 
        aTimer.Interval=5000; // here you can define the time or reset it after each api call
        aTimer.Enabled=true;
