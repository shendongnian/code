    // For .Net 4.5 and previous versions
    public static T RawDeserialize<T>(byte[] bytearray)
        where T : struct
    {
        var type = typeof(T);
        int len = Marshal.SizeOf(type);
    
        IntPtr i = IntPtr.Zero;
        try
        {
            i = Marshal.AllocHGlobal(len);
    
            Marshal.Copy(bytearray, 0, i, len);
    
            return (T)Marshal.PtrToStructure(i, type);
        }
        finally
        {
            if (i != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(i);
            }
        }
    }
