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
    private unsafe static readonly uint* _byteHexCharsP = (uint*)GCHandle.Alloc(_hexConversionLookup, GCHandleType.Pinned).AddrOfPinnedObject();
    private unsafe void TestBufferWith256UintLookupUnsafe(XmlWriter writer, byte[] bytes)
    {
        fixed (byte* bytesP = bytes)
        {
            var bufferIndex = 0;
            var bufferLength = bytes.Length < 2048 ? bytes.Length : 2048;
            var charBuffer = new char[bufferLength * 2];
            fixed (char* bufferP = charBuffer)
            {
                uint* buffer = (uint*)bufferP;
                for (int i = 0; i < bytes.Length; i++)
                {
                    buffer[bufferIndex] = _byteHexCharsP[bytes[i]];
                    bufferIndex++;
                    if (bufferIndex == bufferLength)
                    {
                        writer.WriteRaw(charBuffer, 0, bufferLength * 2);
                        bufferIndex = 0;
                    }
                }
            }
            if (bufferIndex > 0)
                writer.WriteRaw(charBuffer, 0, bufferIndex * 2);
        }
    }
