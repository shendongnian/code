    public static (byte Hibyte, byte Lobyte) GetBytes(short i)
    {   // This is my recommendation; it gets both bytes in one call, so it
        // may be more efficient.
        var bytes = BitConverter.GetBytes(i);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes)
        return (bytes[0], bytes[1]);
    }
    public static (byte Hibyte, byte Lobyte) GetBytes(ushort i)
    {   // BitConverter works equally well with unsigned types.
        var bytes = BitConverter.GetBytes(i);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes)
        return (bytes[0], bytes[1]);
    }
    public static byte Hibyte(short i)
    {   // If you want to use your original schema, here's the hi byte:
        if (BitConverter.IsLittleEndian)
            return BitConverter.GetBytes()[1];
        return BitConverter.GetBytes()[0];
    }
    public static byte Hibyte(ushort i)
    {   // Again, same thing works for ushort
        if (BitConverter.IsLittleEndian)
            return BitConverter.GetBytes()[1];
        return BitConverter.GetBytes()[0];
    }
    public static short MakeShort(byte hb, byte lb)
    {
        byte[] bytes = new byte[] { hb, lb };
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return BitConverter.ToInt16(bytes);
    }
    public static ushort MakeUShort(byte hb, byte lb)
    {
        byte[] bytes = new byte[] { hb, lb };
        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return BitConverter.ToUInt16(bytes);
    }
