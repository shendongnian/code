    public static class ColorExtension
    {
        public static uint[] GetUInts(this Color[] colors)
        {
            if(colors == null) throw new ArgumentNullException("colors");
            Evil e = new Evil { Colors = colors};
            return e.UInts;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct Evil
        {
            [FieldOffset(0)]
            public Color[] Colors;
            [FieldOffset(0)]
	        public uint[] UInts;
        }
    }
