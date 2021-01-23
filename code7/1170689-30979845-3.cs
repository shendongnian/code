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
    
