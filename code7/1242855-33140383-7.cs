    object _locker = new object();
    const int SomeTimeout=1000;
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
       try
       {
           if (Monitor.TryEnter(_locker, SomeTimeout)
           {
               // got lock
           }
           else
           {
               // timed-out, oh well let's march on with the next job
               DoSomething();
               return;
           }
       }
       finally
       {
           Monitor.Exit(_locker);
       }
    }
