    class Clock
    {
        Task t;
        CancellationTokenSource source = new CancellationTokenSource();
        Action<DateTime> updateFunction;
    
        internal Clock(Action<DateTime> updateFunction)
        {
             this.updateFunction = updateFunction;
             t = new Task(() =>
             {
                 while (!source.Token.IsCancellationRequested)
                 {
                     Thread.Sleep(1000);
                     updateFunction(DateTime.Now);
                 }
             }, source.Token);
        }
          
        internal void Start()
        {
            if(t == null) return;
            t.Start();
        }
        internal void Stop()
        {
            source.Cancel();
        }
    }
