    public static UInt64 CountTrailingZeros(UInt64 input)
    {
        if (input == 0) return 64;
        UInt64 n = 1;
        if ((input & 0xFFFFFFFF) == 0) { n = 33; input = input >> 32; }
        if ((input & 0xFFFF) == 0) { n = n + 16; input = input >> 16; }
        if ((input & 0xFF) == 0) { n = n + 8; input = input >> 8; }
        if ((input & 0xF) == 0) { n = n + 4; input = input >> 4; }
        if ((input & 3) == 0) { n = n + 2; input = input >> 2; }
        n = n - (input & 1);
        return n;
    }
