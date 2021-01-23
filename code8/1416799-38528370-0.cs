    ReaderWriterLockSlim m_lock = new ReaderWriterLockSlim();
    public string do2()
    {
        m_lock.EnterReadLock();
        try
        {
            // Do work, many threads can enter this lock at the same time
        }
        finally
        {
            m_lock.ExitReadLock();
        }
    }
    public void do1()
    {
        m_lock.EnterWriteLock();
        try
        {
            // Do work, only one thread can be in here at once
        }
        finally
        {
            m_lock.ExitWriteLock();
        }
    }
