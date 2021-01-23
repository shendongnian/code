    private volatile int noOfProcessed;
    ...
    ...
        Interlocked.Increment(ref noOfProcessed);
        if (MaximumLimitToStopRequest != null) // Warning: this is NOT thread safe
        {
            MaximumLimitToStopRequest(this, noOfProcessed);
        }
    ...
    public int NoOfProcessed
            {
                get
                {
                    return noOfProcessed;
                }
            }
