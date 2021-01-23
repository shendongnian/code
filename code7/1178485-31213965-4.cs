    [DllImport("NativeLibrary", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    public static extern int OnFrame(int pId, IntPtr fi);
    public static int OnFrameSharp(int pId, FrameInfo fi)
    {
        var handle = GCHandle.Alloc(fi, GCHandleType.Pinned);
        try
        {
            IntPtr ptr = handle.AddrOfPinnedObject();
            fi.Image = ptr + 2 * sizeof(double) + IntPtr.Size;
            return OnFrame(pId, ptr);
        }
        finally
        {
            handle.Free();
        }
    }
