    try
    {
        Monitor.Enter(LockObject);
        if (instance == null)
        {
            instance = Instance();
        }
    }
    finally
    {
        Monitor.Exit(LockObject);
    }
