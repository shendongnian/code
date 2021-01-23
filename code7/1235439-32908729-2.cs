    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    [DllExport]
    public static void DoStuff( 
        [In] 
        int arrayCount, 
        [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] 
        IntPtr[] arrays, 
        [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] 
        int[] subArrayCount, 
    )
    {
        MyVector[][] input = new MyVector[arrayCount];
        for (int i = 0; i < arrayCount; i++)
        {
            input[i] = new MyVector[subArrayCount[i]];
            GCHandle gch = GCHandle.Alloc(input[i], GCHandleType.Pinned);
            try
            {
                CopyMemory(
                    gch.AddrOfPinnedObject(), 
                    arrays[i], 
                    (uint)(subArrayCount[i]*Marshal.SizeOf(typeof(MyVector))
                );
            }
            finally
            {
                gch.Free();
            }
        }
    }
    
