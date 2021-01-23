    private static Dictionary<string,Timer> timers = new Dictionary<Guid,Timer>();
    public Guid StartCountdown()
    {           
        // MAY BE A BAD SOLUTION BECAUSE THE APP POOL MAY RECYCLE
        timer.Interval = _timeIntervalInMilliseconds;
        timer.Elapsed += BroadcastToClients;
        var guid = Guid.NewGuid().ToString();
        timers.Add(guid,timer);
        timer.Start();
        return guid;
    }
    public IHttpActionResult CancelCountdown(Guid cancelationToken)
    {
       //If the timer no longer exist or the user supplied a wrong token
       if(!timers.HasKey(cancelationToken)) return; 
       var timer = timers[cancelationToken];
       timer.Stop();
       timer.Dispose();
       timers.Remove(cancelationToken);
    }
