    Timer pingTimer;
    void PingTimerStart()
    {
      pingTimer = new Timer(300000); // 300 seconds - 5 minutes
      pingTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
      pingTimer.Start();
    }
    void TimerTick(object source, ElapsedEventArgs e)
    {
      // Send ping code here
    }
