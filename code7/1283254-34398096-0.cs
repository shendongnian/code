    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Data
    {
    [MarshalAs(UnmanagedType.U4)]
    public int number = 5;
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
    public int[] array = {0, 1, 2, 3, 4};
    
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    public string buffer = "Happy new Year";
    }
