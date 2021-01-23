    private static readonly byte[] asciiValues = 
        Enumerable.Range(0, 128).Select(b => (byte)b).ToArray();
    private static readonly string asciiChars = 
        new string(asciiValues.Select(b => (char)b).ToArray());
    
    public static bool IsAsciiCompatible(Encoding encoding)
    {
        return encoding.GetString(asciiValues).Equals(asciiChars, StringComparison.Ordinal)
            && encoding.GetBytes(asciiChars).SequenceEqual(asciiValues);
    }
