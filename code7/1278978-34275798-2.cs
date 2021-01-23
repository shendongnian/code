    public static class UIntExtensions
    {
        public static bool IsBitSet(this uint i, int bitNumber)
        {
            return i & (1 << bitNumber) != 0;
        }
    }
