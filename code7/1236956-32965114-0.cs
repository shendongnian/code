    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern int memcmp(IntPtr b1, IntPtr b2, UIntPtr count);
    public static bool CompareArrays(Array b1, Array b2)
    {
        if (b1.Length != b2.Length)
            return false;
        if (!b1.GetType().GetElementType().Equals(b2.GetType().GetElementType()))
            return false;
        GCHandle gch1 = GCHandle.Alloc(b1, GCHandleType.Pinned);
        try
        {
            GCHandle gch2 = GCHandle.Alloc(b2, GCHandleType.Pinned);
            try
            {
                return memcmp(gch1.AddrOfPinnedObject(), gch2.AddrOfPinnedObject(), 
                    (UIntPtr)(b1.Length * Marshal.SizeOf(b1.GetType().GetElementType()))) == 0;
            }
            finally
            {
                gch2.Free();
            }
        }
        finally
        {
            gch1.Free();
        }
    }
