        public byte[] getSHA1MessageDigest(string originalKey)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(originalKey, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            IBuffer sha1 = hashAlgorithm.HashData(buffer);
            byte[] newByteArray;
            CryptographicBuffer.CopyToByteArray(sha1, out newByteArray);
            return newByteArray;
        }
