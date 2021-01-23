    public static string tripleDESEncryptor(string toEncrypt, string keyString)
    {
       var crypt = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.TripleDesEcbPkcs7);
                IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(toEncrypt, BinaryStringEncoding.Utf8);
                IBuffer keyBuffer = CryptographicBuffer.ConvertStringToBinary(keyString, BinaryStringEncoding.Utf8);
                CryptographicKey key = crypt.CreateSymmetricKey(keyBuffer);
                IBuffer signed = CryptographicEngine.Encrypt(key, buffer, null);
                string signature = CryptographicBuffer.EncodeToBase64String(signed);
                return signature;
    }
