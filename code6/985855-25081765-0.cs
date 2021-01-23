    unsafe void Main()
    {
        Color[] c = new Color[2]
        {
            new Color { R = 255, G = 0, B = 0, A = 0 },
            new Color { R = 0, G = 255, B = 0, A = 0 }
        };
        c.Dump();
    
    
        fixed (byte* p = &c[0].R)
        {
            *p = 17;
            *(p + 1) = 18;
            *(p + 2) = 19;
            *(p + 3) = 20;
            *(p + 4) = 21;
        };
        c.Dump();
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Color
    {
        public byte R, G, B, A;
    }
