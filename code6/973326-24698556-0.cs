    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Comarea
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string status;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string operationName;
    }
