    const int bufferSize = 256;
    string str = new string('\0', n / bytesPerCharacter);
    byte* bytes = stackalloc byte[bufferSize];
    fixed (char* pinnedChars = str)
    {
        char* chars = pinnedChars;
        for (int i = n; i >= 0; i -= bufferSize)
        {
            int byteCount = Math.Min(bufferSize, i);
            int charCount = byteCount / bytesPerCharacter;
            for (int j = 0; j < byteCount; ++j)
                bytes[j] = (byte)stream.ReadByte();
            encoding.GetChars(bytes, byteCount, chars, charCount);
            chars += charCount;
        }
    }
