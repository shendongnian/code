    [StructLayout(LayoutKind.Sequential, Size = 24)]
    public struct myStruct
    {
        public byte byte1;
        public byte byte2;
        public ushort reserved;
        //Was char[16]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name; // null terminated
        public uint version;
    }
