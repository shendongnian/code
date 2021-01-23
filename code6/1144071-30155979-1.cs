    private static readonly Encoding Encoding1252 = Encoding.GetEncoding(1252);
    /// <summary>
    /// Compute hash for string encoded as Windows-1252
    /// </summary>
    /// <param name="s">String to be hashed</param>
    /// <returns>40-character hex string</returns>
    public static string SHA1HashStringForDefaultString(string s)
    {
        byte[] bytes = Encoding1252.GetBytes(s);
