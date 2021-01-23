    [StructLayout(LayoutKind.Explicit)]
    public struct Evil
    {
        [FieldOffset(0)]
        public Color[] Colors;
        [FieldOffset(0)]
	    public uint[] Uints;
    }
