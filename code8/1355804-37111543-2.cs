    public static long SearchBytePattern(byte[] source, byte[] patternToFind)
    {
        int incomingOffset = 0;
        byte[] window = new byte[1024];
        long count = 0;
        KMP kmp = new KMP(patternToFind);
        while (incomingOffset < source.Length)
        {
            int length = Math.Min(window.Length, source.Length - incomingOffset);
            Buffer.BlockCopy(source, incomingOffset, window, 0, length);
            incomingOffset += length;
            count += kmp.match(window);
            if (incomingOffset >= source.Length)
                break;
            else
                incomingOffset -= patternToFind.Length - 1;
        }
        return count;
    }
