    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    [DllExport]
    public static void DoStuff(
        [In] IntPtr[] arrays,
        [In] int arrayCount,
        [In] int[] subArrayCount
    )
    {
        MyVector[][] input = new MyVector[arrayCount];
        for (int i = 0; i < arrayCount; i++)
        {
            input[i] = new MyVector[subArrayCount[i]];
            GCHandle gch = GCHandle.Alloc(input[i], GCHandleType.Pinned);
            try
            {
                Marshal.Copy(arrays[i], gch.AddrOfPinnedObject(), (uint)subArrayCount[i]);
            }
            finally
            {
                gch.Free();
            }
        }
    }
    
