    [StructLayout(LayoutKind.Explicit)]
    public struct DecimalSplitted
    {
        [FieldOffset(0)]
        public uint UInt0;
        [FieldOffset(4)]
        public uint UInt1;
        [FieldOffset(8)]
        public uint UInt2;
        [FieldOffset(12)]
        public uint UInt3;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct DecimalToUint
    {
        [FieldOffset(0)]
        public DecimalSplitted Splitted;
        [FieldOffset(0)]
        public decimal Decimal;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct StructConverter
    {
        [FieldOffset(0)]
        public decimal[] Decimals;
        [FieldOffset(0)]
        public DecimalSplitted[] Splitted;
    }
