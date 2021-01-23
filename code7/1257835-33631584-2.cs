    #region IDisposable
    //Dispose() calls Dispose(true)
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    // NOTE: Delete the finalizer if this class doesn't 
    // own unmanaged resources itself.
    ~ClassName() 
    {
        //Finalizer calls Dispose(false)
        Dispose(false);
    }
    //The bulk of the clean-up code is implemented in Dispose(bool)
    protected virtual void Dispose(bool disposing)
    {
        if (disposing) 
        {
            //free managed resources (Example below)
            if (managedResource != null)
            {
                managedResource.Dispose();
                managedResource = null;
            }
        }
        //Free native resources if there are any. (Example below)
        if (nativeResource != IntPtr.Zero) 
        {
            Marshal.FreeHGlobal(nativeResource);
            nativeResource = IntPtr.Zero;
        }
    }
    #endregion
