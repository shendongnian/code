    public enum MyEnum : int { A, B }
    [StructLayout(LayoutKind.Explicit)]
    struct IntEnumUnion
    {
        [FieldOffset(0)]
        public MyEnum Enum;
        [FieldOffset(0)]
        public int Int;
    }
    private static IntEnumUnion s_field;
