    ~ClassName()
    {
        Dispose(false);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if(_disposed)
            return;
        
        try
        {
            if(disposing)
            {
                //  Dispose objects here
            }
        }
        finally
        {
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
