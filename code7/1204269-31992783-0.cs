    if (Monitor.TryEnter(_lock))
    {
        try
        {
            ExecuteTask();
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
