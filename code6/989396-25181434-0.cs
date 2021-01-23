    volatile bool keepRunning = true;
    Thread workerThread;
    protected override void OnStart(string[] args)
    {
        workerThread = new Thread(() =>
        {
            while(keepRunning)
            {
                DoWork();
                Thread.Sleep(10 * 60 * 1000); // Sleep for ten minutes
            }
        });
        workerThread.Start();
    }
    protected override void OnStop()
    {
        keepRunning = false;
        workerThread.Join();
        // Ended gracefully
    }
