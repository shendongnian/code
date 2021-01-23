    private void Increment()
    {
        lock (syncLock)
        {
            i++;
            Monitor.PulseAll(syncLock);
        }
    }
    
    private void Decrement()
    {
        lock (syncLock)
        {
            i--;
            Monitor.PulseAll(syncLock);
        }
    }
