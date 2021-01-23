    public static IEnumerable<Boolean> BytesToBooleans(IEnumerable<Byte> bytes)
    {
        if (bytes == null)
            throw new ArgumentNullException("bytes");
        return bytes
            .Select(b =>
                {
                    if (b == 0xF0)
                        return false;
                    if (b == 0xFF)
                        return true;
                    throw new ArgumentException();
                });
    }
