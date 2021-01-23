    /// <summary>
    ///     [...]
    ///     Although this method allows a 32-bit value
    ///     to be passed for each component, the value of each
    ///     component is limited to 8 bits.
    /// </summary>
    public static Color FromArgb(int alpha, int red, int green, int blue)
    {
        Color.CheckByte(alpha, "alpha");
        Color.CheckByte(red, "red");
        Color.CheckByte(green, "green");
        Color.CheckByte(blue, "blue");
        return new Color(Color.MakeArgb((byte)alpha, (byte)red, (byte)green, (byte)blue), Color.StateARGBValueValid, null, (KnownColor)0);
    }
    
    private static long MakeArgb(byte alpha, byte red, byte green, byte blue)
    {
        return (long)((ulong)((int)red << 16 | (int)green << 8 | (int)blue | (int)alpha << 24) & (ulong)-1);
    }
    
    private static void CheckByte(int value, string name)
    {
        if (value < 0 || value > 255)
        {
            throw new ArgumentException(SR.GetString("InvalidEx2BoundArgument",
                                        name,
                                        value,
                                        0,
                                        255));
        }
    }
