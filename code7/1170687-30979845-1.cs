       void Dispose(bool disposing)
    {
        if (handle != IntPtr.Zero)
        {
            DestroyHandle();
        }
    }
    
    internal void DestroyHandle()
    {
        if (ownHandle)
        {
            SafeNativeMethods.DestroyIcon(new HandleRef(this, handle));
            handle = IntPtr.Zero;
        }
    }
    
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    void Dispose(bool disposing)
    {
        if (handle != IntPtr.Zero)
        {
            DestroyHandle();
        }
    }
