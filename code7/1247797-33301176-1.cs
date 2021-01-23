        /// <summary>
        /// Parses a continuous hex stream from a string.
        /// </summary>
        public static byte[] ParseHexBytes(this string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (s.Length == 0)
                return new byte[0];
            if (s.Length % 2 != 0)
                throw new ArgumentException("Source length error", "s");
            int length = s.Length >> 1;
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = Byte.Parse(s.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return result;
        }
