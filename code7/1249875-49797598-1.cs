    public static byte Hibyte(ushort i)
    { return (byte)(i >> 8); }
    // No need for unchecked, because result will always fit in one byte and is never < 0.
    public static byte Lobyte(ushort i)
    { return (byte)(i & 0xFF); } // No need for unchecked for the same reason.
    public static byte LoByte(short i)
    { return (byte)(i & 0xFF); } 
    // Like above, no need for unchecked for the same reasons; also, bitwise & works the same 
    // for both signed and unsigned types.
    public static ushort MakeUShort(byte hb, byte lb)
    { return (ushort)((hb << 8) | lb); } 
    // Again, no need for unchecked; result is always 16 bits and never negative.
    public static short MakeShort(byte hb, byte lb)
    { unchecked { return (short)((hb << 8) | lb); } }
    // This time, we may need unchecked because result may overflow short.
