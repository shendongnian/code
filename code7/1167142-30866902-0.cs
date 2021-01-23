    /// <summary>
    /// local helper method to acquire all local lists locks
    /// </summary>
    private void AcquireAllLocks()
    {
        Contract.Assert(Monitor.IsEntered(GlobalListsLock));
 
        bool lockTaken = false;
        ThreadLocalList currentList = m_headList;
        while (currentList != null)
        {
            // Try/Finally bllock to avoid thread aport between acquiring the lock and setting the taken flag
            try
            {
                Monitor.Enter(currentList, ref lockTaken);
            }
            finally
            {
                if (lockTaken)
                {
                    currentList.m_lockTaken = true;
                    lockTaken = false;
                }
            }
            currentList = currentList.m_nextList;
        }
    }
