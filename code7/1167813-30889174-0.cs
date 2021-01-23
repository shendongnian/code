    public static byte[] NumberToByteArray(float f, int decimals)
    {
        // A string in the format 0000000000.00 for example
        string format = new string('0', 12 - decimals) + "." + new string('0', decimals);
        // We format the number f, removing the decimal separator
        string str = f.ToString(format, CultureInfo.InvariantCulture).Replace(".", string.Empty);
        if (str.Length != 12)
        {
            throw new ArgumentException("f");
        }
        var bytes = new byte[6];
        for (int i = 0; i < 6; i++)
        {
            // For each group of two digits, the first one is shifted by
            // 4 binary places
            int digit1 = str[i * 2] - '0';
            bytes[i] = (byte)(digit1 << 4);
            // And the second digit is "added" with the logical | (or)
            int digit2 = str[(i * 2) + 1] - '0';
            bytes[i] |= (byte)digit2;
        }
        return bytes;
    }
