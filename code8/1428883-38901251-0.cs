        public string Hash(string input)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            var hashByte = hashAlgorithm.HashData(buffer).ToArray();
            var sb = new StringBuilder(hashByte.Length * 2);
            foreach (byte b in hashByte)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
