    private static readonly uint[] _hexConversionLookup = CreateHexConversionLookup();
    private static uint[] CreateHexConversionLookup()
    {
        var result = new uint[256];
        for (int i = 0; i < 256; i++)
        {
            string s = i.ToString("X2");
            result[i] = ((uint)s[0]) + ((uint)s[1] << 16);
        }
        return result;
    }
    private void TestBufferWith256UintLookup(XmlWriter writer, byte[] bytes)
    {
        unchecked
        {
            var bufferIndex = 0;
            var bufferLength = bytes.Length < 2048 ? bytes.Length * 2 : 4096;
            var buffer = new char[bufferLength];
            for (int i = 0; i < bytes.Length; i++)
            {
                var b = _hexConversionLookup[bytes[i]];
                buffer[bufferIndex] = (char)b;
                buffer[bufferIndex + 1] = (char)(b >> 16);
                bufferIndex += 2;
                if (bufferIndex == bufferLength)
                {
                    writer.WriteRaw(buffer, 0, bufferLength);
                    bufferIndex = 0;
                }
            }
            if (bufferIndex > 0)
                writer.WriteRaw(buffer, 0, bufferIndex);
        }
    }
