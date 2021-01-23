    System.Timers.Timer aTimer = new System.Timers.Timer();
    System.Timers.ElapsedEventHandler handler = null;
    handler = ((sender, args)
          =>
         {
             aTimer.Elapsed -= handler;
             wc.CancelAsync();
          });
    aTimer.Elapsed += handler;
    aTimer.Interval = 100000;
    aTimer.Enabled = true;
