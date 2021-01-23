    class StringSet
    {
        private const int HalfOfInt32Max = Int32.MaxValue / 2;
        /* snip */
        private Int32 NewMax(int oldMax)
        {
            if (oldMax < HalfOfInt32Max)
            {
                return oldMax * 2;
            }
            return Int32.MaxValue;
        }
    }
