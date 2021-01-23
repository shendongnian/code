    public void Wait()
    {
    #if DEBUG
        bool waitResult =
    #endif
        Wait(Timeout.Infinite, default(CancellationToken));
     
    #if DEBUG
        Contract.Assert(waitResult, "expected wait to succeed");
    #endif
    }
