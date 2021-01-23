        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public unsafe struct StructMessage
        {
            [FieldOffset(0)] public fixed byte data[36];
            [FieldOffset(0)] public int TimeMilis;
            [FieldOffset(4)] public fixed float Q[4];
            [FieldOffset(20)] public fixed float QD[4];
        }
