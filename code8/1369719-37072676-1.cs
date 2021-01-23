    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    public struct SOMELIKE_STRUCT
    {
        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 48 )]
        public byte[] a;
        public byte b;
        public byte c;
        public byte d;
        public byte e;
        public byte f;
        public byte x;
        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32 )]
        public byte[] y;
        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 128 )]
        public STRUCT[] z;
    }
    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    public struct STRUCT
    {
        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32 )]
        public byte[] name;
    }
