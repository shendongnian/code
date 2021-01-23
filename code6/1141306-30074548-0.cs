        public static BigInteger FromBigEndian(byte[] p)
        {
            p = p.Reverse().Concat(new byte[] { 0 }).ToArray();
            return new BigInteger(p);
        }
