    public void YourFunction()
    {
        bool enteredUpgLock = false;
        bool enteredWriteLock = false;
        try
        {
            //Preemptively take a upgradeable read lock, only one thread can do this.
            enteredUpgLock = _readerWriterLock.TryEnterUpgradeableReadLock(0);
            try
            {
                //If we don't have the upgradeable lock take a normal read lock.
                if (!enteredUpgLock)
                {
                    _readerWriterLock.EnterReadLock();
                }
                DoReadWork();
            }
            finally
            {
                //Release the read lock if we had it.
                if(!enteredUpgLock)
                    _readerWriterLock.ExitReadLock();
            }
            try
            {
                if (enteredUpgLock)
                {
                    //We held the upgradeable lock, wait forever till we can take it.
                    _readerWriterLock.EnterWriteLock();
                    enteredWriteLock = true;
                }
                else
                {
                    //We did not have the upgrade lock, try to take the write lock but if we can't bail out.
                    enteredWriteLock = _readerWriterLock.TryEnterWriteLock(0);
                    if(!enteredWriteLock)
                        return;
                }
                DoWriteWork();
            }
            finally 
            {
                if(enteredWriteLock)
                    _readerWriterLock.ExitWriteLock();
            }
        }
        finally 
        {
            //If we had the upgradeable lock, release it.
            if (enteredUpgLock)
            {
                _readerWriterLock.ExitUpgradeableReadLock();
            }
        }
    }
