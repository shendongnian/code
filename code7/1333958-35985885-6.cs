    private static int popCount(BitArray simRes)
    {
        Int32[] ints = new Int32[(simRes.Count >> 5) + 1];
        simRes.CopyTo(ints, 0);
        Int32 count = 0;
        // fix for not truncated bits in last integer that may have been set to true with SetAll()
        ints[ints.Length - 1] &= ~(-1 << (simRes.Count % 32));
        for (Int32 i = 0; i < ints.Length; i++)
        {
            Int32 c = ints[i];
            if (c == 0)
            {
                continue;
            }
            // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
            unchecked
            {
                c = c - ((c >> 1) & 0x55555555);
                c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
            }
            count += c;
        }
        return count;
    }
