    private static int[] _guidByteOrder = { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
    public static Guid NextGuid(this Guid guid)
    {
        var bytes = guid.ToByteArray();
        for (int i = 0; i < 16; i++)
        {
            var iByte = _guidByteOrder[i];
            unchecked { bytes[iByte] += 1; }
            if (bytes[iByte] != 0)
                return new Guid(bytes);
        }
        return Guid.Empty;
    }
