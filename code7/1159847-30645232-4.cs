    {
        // I case:
        IntPtr ret = IntPtr.Zero;
        int result = method2('I', ref ret);
    }
    {
        // R case:
        IntPtr ptr = IntPtr.Zero;
        int result = method2('R', ref ptr);
        int value = Marshal.ReadInt32(ptr);
    }
    {
        // W case:
        int value = 100;
        byte[] bytes = BitConverter.GetBytes(value);
        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            int result = method2('W', ref ptr);
        }
        finally
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }
