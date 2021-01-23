    public static byte[] Replace10With1010ExcludingFirstAndLastByte(byte[] input)
    {
        //  Count 10s excluding first and last byte.
        int count = input.Skip(1).Take(input.Length-2).Count(b => b == 10);
        // Create output array of appropriate size.
        byte[] result = new byte[input.Length +  count];
        // Copy input to output, duplicating all 10s that are not the first byte.
        result[0] = input[0];
        for (int i = 1, j = 1; i < input.Length; ++i, ++j)
        {
            result[j] = input[i];
            if ((input[i] == 10) && (i != (input.Length-1)))
                result[++j] = 10;
        }
        return result;
    }
