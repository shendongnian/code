    public static class IntExtensions
    {
        public static bool IsBitSet(this int i, int bitNumber)
        {
            return i & (1 << bitNumber) != 0;
        }
    }
