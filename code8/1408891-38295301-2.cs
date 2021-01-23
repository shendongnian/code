    private const int _khighOffset = 0xD800 - (0x10000 >> 10);
    /// <summary>
    /// Decodes a nominally UTF8 byte sequence as UTF16. Ignores all data errors
    /// except those which prevent coherent interpretation of the input data.
    /// Input with invalid-but-decodable UTF8 sequences will be decoded without
    /// error, and may lead to invalid UTF16.
    /// </summary>
    /// <param name="bytes">The UTF8 byte sequence to decode</param>
    /// <returns>A string value representing the decoded UTF8</returns>
    /// <remarks>
    /// This method has not been thoroughly validated. It should be tested
    /// carefully with a broad range of inputs (the entire UTF16 code point
    /// range would not be unreasonable) before being used in any sort of
    /// production environment.
    /// </remarks>
    private static string DecodeUtf8WithOverlong(byte[] bytes)
    {
        List<char> result = new List<char>();
        int continuationCount = 0, continuationAccumulator = 0, highBase = 0;
        char continuationBase = '\0';
        for (int i = 0; i < bytes.Length; i++)
        {
            byte b = bytes[i];
            if (b < 0x80)
            {
                result.Add((char)b);
                continue;
            }
            if (b < 0xC0)
            {
                // Byte values in this range are used only as continuation bytes.
                // If we aren't expecting any continuation bytes, then the input
                // is invalid beyond repair.
                if (continuationCount == 0)
                {
                    throw new ArgumentException("invalid encoding");
                }
                // Each continuation byte represents 6 bits of the actual
                // character value
                continuationAccumulator <<= 6;
                continuationAccumulator |= (b - 0x80);
                if (--continuationCount == 0)
                {
                    if (continuationAccumulator > 0xffff)
                    {
                        // Code point requires more than 16 bits, so split into surrogate pair
                        char highSurrogate = (char)(_khighOffset + (continuationAccumulator >> 10)),
                            lowSurrogate = (char)(0xDC00 + (continuationAccumulator & 0x3FF));
                        result.Add(highSurrogate);
                        result.Add(lowSurrogate);
                    }
                    else
                    {
                        result.Add((char)(continuationBase | continuationAccumulator));
                    }
                    continuationAccumulator = 0;
                    continuationBase = '\0';
                    highBase = '\0';
                }
                continue;
            }
            if (b < 0xE0)
            {
                continuationCount = 1;
                continuationBase = (char)((b - 0xC0) * 0x0040);
                continue;
            }
            if (b < 0xF0)
            {
                continuationCount = 2;
                continuationBase = (char)(b == 0xE0 ? 0x0800 : (b - 0xE0) * 0x1000);
                continue;
            }
            if (b < 0xF8)
            {
                continuationCount = 3;
                highBase = (b - 0xF0) * 0x0004;
                continue;
            }
            if (b < 0xFC)
            {
                continuationCount = 4;
                highBase = (b - 0xF8) * 0x0100;
                continue;
            }
            if (b < 0xFE)
            {
                continuationCount = 5;
                highBase = (b - 0xFC) * 0x4000;
                continue;
            }
            // byte values of 0xFE and 0xFF are invalid
            throw new ArgumentException("invalid encoding");
        }
        return new string(result.ToArray());
    }
