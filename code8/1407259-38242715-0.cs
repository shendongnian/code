    public string Decrypt(string input, string pass)
    {
        var keyHash = Encoding.ASCII.GetBytes(GetMD5Hash(pass));
    
        // Create a buffer that contains the encoded message to be decrypted.
        IBuffer toDecryptBuffer = CryptographicBuffer.DecodeFromBase64String(input);
    
        // Open a symmetric algorithm provider for the specified algorithm.
        SymmetricKeyAlgorithmProvider aes = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcb);
    
        // Create a symmetric key.
        var symetricKey = aes.CreateSymmetricKey(keyHash.AsBuffer());
    
        var buffDecrypted = CryptographicEngine.Decrypt(symetricKey, toDecryptBuffer, null);
    
        string strDecrypted = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, buffDecrypted);
    
        return strDecrypted;
    }
