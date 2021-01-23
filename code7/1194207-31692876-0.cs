    // Starts the worker thread that gets rid of the queue:
    internal void Start()
    {
        loggingWorker = new Thread(LogHandler)
        {
            Name = "Logging worker thread",
            IsBackground = true,
            Priority = ThreadPriority.BelowNormal
        };
        loggingWorker.Start();
    }
