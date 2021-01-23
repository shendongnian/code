    public static unsafe void MemcpyExample()
    {
         int src = 12345;
         int dst = 0;
         Buffer.Memcpy((byte*) &dst, (byte*) &src, sizeof (int));
         System.Diagnostics.Debug.Assert(dst==12345);
    }
