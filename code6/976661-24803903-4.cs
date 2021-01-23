    if(cachedSettings.RequiresUpdate())
    {
        _rw.EnterWriteLock();
        try
        {
            if(cachedSettings.RequiresUpdate())
            {
                UpdateSettings( cachedSettings, sessionId );
            }
        }
        finally
        {
            _rw.ExitWriteLock();
        }
    }
