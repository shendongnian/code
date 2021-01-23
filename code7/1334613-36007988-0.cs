    object _processLock;
    // acquiring lock,
    if(Monitor.TryEnter(_processLock)) // if acquired - exit immediately
        try
        {
            ...
        }
        finally { Monitor.Exit(_processLock); }
