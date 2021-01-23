    [StructLayout(LayoutKind.Explicit)]
    public struct Test
    {
        [FieldOffset(0)]
        public byte icode;
        [FieldOffset(1)]
        public byte method;
        [FieldOffset(2)]
        public byte wav;
        [FieldOffset(3)]
        public byte wav2;
        [FieldOffset(4)]
        public byte unit;
        [FieldOffset(5)]
        public byte temp;
        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] itemname;
    }
