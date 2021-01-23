    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public uint MsgId;
        public uint DLC;
        public uint Interval;
        public uint Handle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] Data;
    };
