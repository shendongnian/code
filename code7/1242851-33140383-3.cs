    Monitor _monitor = new ...;
    const int SomeTimeout=1000;
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
       if (Monitor.TryEnter(_monitor, SomeTimeout)
       {
             // got lock
       }
       else
       {
            // timed-out, oh well let's march on with the next job
       }
    }
