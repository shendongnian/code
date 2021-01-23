    public static class ByteExtensions
    {
        public static bool GetBit(this byte byteValue, int bitIndex)
        {
            return (byteValue & (1 << bitIndex - 1)) != 0;
        }
        public static int GetMaxBitIndex(this byte byteValue)
        {
            for (int i = 32; i > -1; i--)
            {
                if (byteValue.GetBit(i))
                    return i;
            }
            return -1;
        }
    }
