    [StructLayout(LayoutKind.Sequential)]
    public struct FormattedMessage_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxStrLength)]
        public string Message;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10*MaxStrLength)]
        public byte[] ParamStrings;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] GetParamStrs;
        public int ParamCount;
        public const int MaxStrLength = StrMax;
    }
