    finally
    {
        IDisposable disposable = reader;
        try
        {
        }
        finally
        {
            if (dispoable != null)
            {
                disposable.Dispose();
            }
        }
    }
