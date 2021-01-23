    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit, Size = 276, Pack = 1)]
    public struct NewStuff
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        [FieldOffset(0)]
        public string Name;
        [MarshalAs(UnmanagedType.U8)]
        [FieldOffset(256)]
        public UInt64 uncompressedSize;
        [MarshalAs(UnmanagedType.U8)]
        [FieldOffset(264)]
        public UInt64 compressedSize;
        [MarshalAs(UnmanagedType.U2)]
        [FieldOffset(272)]
        public UInt16 compressionMethod;
    }
