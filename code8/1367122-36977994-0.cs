    var task = Task.Run(() => worker(stopAfter30Mins.Token), stopAfter30Mins.Token);
    ...
    static void worker(CancellationToken cancellation)
    {
        while (true)  // Or until work completed.
        {
            cancellation.ThrowIfCancellationRequested();
            Thread.Sleep(1000); // Simulate work.
        }
    }
    
