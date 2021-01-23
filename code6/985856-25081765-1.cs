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
            uint* i = (uint*)p;
            *i = 0x11223344;
            *(i + 1) = 0x55667788;
        };
        c.Dump();
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Color
    {
        public byte R, G, B, A;
    }
