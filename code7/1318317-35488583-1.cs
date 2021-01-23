    protected override void Dispose(bool disposing)
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
            base.Dispose(disposing);
        }
    }
