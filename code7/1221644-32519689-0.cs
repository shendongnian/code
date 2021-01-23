    public static byte[] Replace10With1010ExcludingFirstByte(byte[] input)
    {
        //  Count 10s excluding first byte.
        int count = input.Skip(1).Count(b => b == 10);
        // Create output array of appropriate size.
        byte[] result = new byte[input.Length +  count];
        // Copy input to output, duplicating all 10s that are not the first byte.
        result[0] = input[0];
        for (int i = 1, j = 1; i < input.Length; ++i, ++j)
        {
            result[j] = input[i];
            if (input[i] == 10)
                result[++j] = 10;
        }
        return result;
    }
