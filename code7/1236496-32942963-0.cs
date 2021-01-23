    StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct TELEPHONE
    {
        [FieldOffset(0)]
        public int area_code;
        [FieldOffset(4)]
        public int number;
        [FieldOffset(8)]
        public basic_callback               basic_callbck;
    }
