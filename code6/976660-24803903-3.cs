    _rw.EnterUpgradeableReadLock();
    try
    {
        //Do your job
    }
    finally
    {
        _rw.ExitUpgradeableReadLock();
    }
