    public Color MakeTransparent(Color c, int threshold)
    {   // calculate the weighed brightness:
        byte val = (byte)((c.R * 0.299f + c.G * 0.587f + c.B * 0.114f));
        return val < threshold ?  Color.FromArgb(0, c.R, c.G, c.B) : c;
    }
