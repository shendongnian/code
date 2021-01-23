    public static class NumberUtils
    {
        public static byte WithBit(this byte number, int bitPosition, bool value)
        {
            if(bitPosition < 0 || bitPosition > 7)
                throw new InvalidOperationException("bit position must be between 0 and 7");
            if(value) 
                return (byte)(number | (1 << bitPosition));
            else 
                return (byte)(number & ~(1 << bitPosition));
        }
    }
