    ReaderWriterLockSlim theLock = new ReaderWriterLockSlim();
    void Delete(filename)
    {
        theLock.EnterWriteLock();
        try
        {
            // do delete stuff here
        }
        finally
        {
            theLock.ExitWriteLock();
        }
    }
    void Download(filename)
    {
        theLock.EnterReadLock();
        try
        {
            // do delete stuff here
        }
        finally
        {
            theLock.ExitReadLock();
        }
    }        
