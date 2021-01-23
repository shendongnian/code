    private HashSet<int> m_processDataCommandThreadIds = new HashSet<int>();
    
    public void PauseDataCommandProcessing()
    {
        if (m_processDataCommandThreadIds.Contains(Thread.CurrentThread.ManagedThreadId))
        {
            return;
        }
        lock (m_pauseLock)
        {
            m_pauseCounter++;
            if (m_dataCommandInProgress)
            {
                Monitor.Wait(m_pauseLock);
            }
        }
    }
    
    
    public void ResumeDataCommandProcessing()
    {
        if (m_processDataCommandThreadIds.Contains(Thread.CurrentThread.ManagedThreadId))
        {
            return;
        }
        lock (m_pauseLock)
        {
            m_pauseCounter--;
            if (m_pauseCounter == 0)
            {
                Monitor.PulseAll(m_pauseLock);
            }
        }
    }
    
    //Thoses methods are called by the command executers
    public void FlagCommandsExecutionInProgress()
    {
        m_processDataCommandThreadIds.Add(Thread.CurrentThread.ManagedThreadId);
        lock (m_pauseLock)
        {
            while (m_pauseCounter > 0)
            {
                Monitor.Wait(m_pauseLock);
            }
            m_dataCommandInProgress = true;
        }
    }
    
    public void FlagCommandsExecutionFinished()
    {
        m_processDataCommandThreadIds.Remove(Thread.CurrentThread.ManagedThreadId);
        lock (m_pauseLock)
        {
            m_dataCommandInProgress = false;
            Monitor.PulseAll(m_pauseLock);
        }
    }
