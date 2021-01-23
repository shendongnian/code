    // at class scope
    // Flush every 5 minutes.
    private readonly TimeSpan FlushDelay = TimeSpan.FromMinutes(5);
    private const int MaxBufferItems = 1000;
    // Create a timer for the buffer flush.
    System.Threading.Timer _flushTimer = new System.Threading.Timer(TimedFlush, FlushDelay.TotalMilliseconds, Timeout.Infinite);  
    // A lock for the list. Unless you're getting hundreds of thousands
    // of items per second, this will not be a performance problem.
    object _listLock = new Object();
    List<BrokeredMessage> _recordBuffer = new List<BrokeredMessage>();
