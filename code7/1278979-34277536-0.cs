    public static class UIntExtensions
    {
        public static byte[] GetBitArray(this uint v)
        {
            var r = byte[32];
            for (var i = 0; i < 32; ++i)
            {
                r[i] = v & 1;
                v = v >> 1
            }
            return r;
        }
    }
