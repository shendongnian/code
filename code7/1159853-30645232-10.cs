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
        GCHandle handle = default(GCHandle);
        try
        {
            int[] value2 = new int[] { value };
            handle = GCHandle.Alloc(value2, GCHandleType.Pinned);
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
