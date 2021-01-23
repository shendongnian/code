        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public unsafe struct StructMessage
        {
            [FieldOffset(0)] public fixed byte data[13]
            [FieldOffset(0)] public byte Member1;
            [FieldOffset(1)] public Uint Member2;
            [FieldOffset(5)] public fixed UInt16 Member3[4];
        }
