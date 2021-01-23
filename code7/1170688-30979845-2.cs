    public static Icon FromHandle(IntPtr handle)
    {
        IntSecurity.ObjectFromWin32Handle.Demand();
        return new Icon(handle);
    }
    internal Icon(IntPtr handle) : this(handle, false)
    {
    }
    internal Icon(IntPtr handle, bool takeOwnership)
    {
        if (handle == IntPtr.Zero)
        {
            throw new ArgumentException(SR.GetString(SR.InvalidGDIHandle,
                  (typeof(Icon)).Name));
        }
        this.handle = handle;
        this.ownHandle = takeOwnership;
    }
