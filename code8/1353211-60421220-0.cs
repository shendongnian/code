    [StructLayout(LayoutKind.Sequential)]
    public struct S1
    {
        [MarshalAs(UnmanagedType.I1)] public byte _b1; 
        [MarshalAs(UnmanagedType.I1)] public byte _b2; 
        public S1(ushort _ushort)
        {
            this = new Converter(_ushort).s1;
        }
        public ushort USHORT() //for arrays
        {
            return new Converter(this).USHORT;
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct Converter
        {
            [FieldOffset(0)] public S1 s1;
            [FieldOffset(0)] public ushort USHORT;
            public Converter(S1 _s1)
            {
                USHORT = 0;
                s1 = _s1;
            }
            public Converter(ushort _USHORT)
            {
                s1 = default;
                USHORT = _USHORT;
            }
        }
    }
    public unsafe struct S2
    {
        public fixed ushort s1[100];
        public S1 this[int n] {
            get => new S1(s1[n]); //copy!
            set => s1[n] = value.USHORT();
        }
    }
