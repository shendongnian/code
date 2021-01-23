    using System.Timers;
    class MyClass : IDisposable
    {
      readonly Timer aTimer = new Timer(20000);
   
      public void StartTimer()
      {
        this.aTimer.Elapsed += this.OnTimedEvent;
        this.aTimer.Enabled = true;
      }
      void OnTimedEvent(object source, ElapsedEventArgs e)
      {
        // do your background work here
      }
    }
