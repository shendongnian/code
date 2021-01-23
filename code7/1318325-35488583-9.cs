    protected override void Dispose(bool disposing)
    {
        if(_disposed)
            return;
        try
        {
            // DISPOSE OF UN-MANAGED RESOURCES HERE
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
