    public sealed class XorShiftRng
    {
        public XorShiftRng(ulong seed1, ulong seed2)
        {
            if (seed1 == 0 && seed2 == 0)
                throw new ArgumentException("seed1 and seed 2 cannot both be zero.");
            s[0] = seed1;
            s[1] = seed2;
        }
        public ulong NextUlong()
        {
            unchecked
            {
                ulong s0 = s[p];
                ulong s1 = s[p = (p + 1) & 15];
                s1 ^= s1 << 31;
                s[p] = s1 ^ s0 ^ (s1 >> 11) ^ (s0 >> 30);
                return s[p]*1181783497276652981;
            }
        }
        public long NextLong(long minValue, long maxValue)
        {
            if (minValue >= maxValue)
            {
                if (minValue == maxValue)
                {
                    return minValue;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(minValue), "Next() called with minValue > maxValue");
                }
            }
            return (int)(this.NextUlong() / ((double)ulong.MaxValue / (maxValue - minValue)) + minValue);
        }
        public int NextInt(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
            {
                if (minValue == maxValue)
                {
                    return minValue;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(minValue), "Next() called with minValue > maxValue");
                }
            }
            return (int)(this.NextUlong() / ((double)ulong.MaxValue / (maxValue - minValue)) + minValue);
        }
        readonly ulong[] s = new ulong[16];
        int p;
    }
