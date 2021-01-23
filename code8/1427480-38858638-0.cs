        static BigInteger RandomInteger(int bits)
        {
            var bytes = new byte[(bits + 7) / 8 + 1];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(bytes, 0, bytes.Length - 1);
            var remainingBits = bits % 8;
            if (remainingBits > 0)
                bytes[bytes.Length - 2] &= (byte)((1 << remainingBits) - 1);
            return new BigInteger(bytes);
        }
