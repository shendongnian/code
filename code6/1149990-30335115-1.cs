        public static byte[] GetHash(string inputString)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            HashAlgorithm algorithm = SHA1.Create();
            return algorithm.ComputeHash(bytes);
        }
