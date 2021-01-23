    private Thread loggingWorker = null;
    private int loggingWorkerState = 0;
    private ManualResetEventSlim waiter = new ManualResetEventSlim();
    private ConcurrentQueue<Tuple<LogMessageHandler, string>> queue =
        new ConcurrentQueue<Tuple<LogMessageHandler, string>>();
    private void LogHandler(object o)
    {
        Interlocked.Exchange(ref loggingWorkerState, 1);
        while (Interlocked.CompareExchange(ref loggingWorkerState, 1, 1) == 1)
	    {
            waiter.Wait(TimeSpan.FromSeconds(10.0));
            waiter.Reset();
            Tuple<LogMessageHandler, string> item;
            while (queue.TryDequeue(out item))
            {
                writeToFile(item.Item1, item.Item2);
            }
        }
	}
