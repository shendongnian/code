    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MYDATA
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
        public string calls;      
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
        public string Desc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string error;     
    }
