    public void YourFunction()
    {
        try
        {
            //Preemptively take a upgradeable read lock, only one thread can do this.
            _readerWriterLock.TryEnterUpgradeableReadLock(0);
            try
            {
                //If we don't have the upgradeable lock take a normal read lock.
                if(!_readerWriterLock.IsUpgradeableReadLockHeld)
                    _readerWriterLock.EnterReadLock();
                DoReadWork();
            }
            finally
            {
                //If we had a normal read lock at this point we need to release it.
                if(_readerWriterLock.IsReadLockHeld)
                    _readerWriterLock.ExitReadLock();
            }
            try
            {
                if (_readerWriterLock.IsUpgradeableReadLockHeld)
                {
                    //We held the upgradeable lock, wait forever till we can take it.
                    _readerWriterLock.EnterWriteLock();
                }
                else
                {
                    //We did not have the upgrade lock, try to take the write lock but if we can't bail out.
                    if(!_readerWriterLock.TryEnterWriteLock(0))
                        return;
                }
                DoWriteWork();
            }
            finally 
            {
                if(_readerWriterLock.IsWriteLockHeld)
                    _readerWriterLock.ExitWriteLock();
            }
        }
        finally 
        {
            //If we had the upgradeable lock, release it.
            if (_readerWriterLock.IsUpgradeableReadLockHeld)
            {
                _readerWriterLock.ExitUpgradeableReadLock();
            }
        }
    }
