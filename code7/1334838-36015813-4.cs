    public static string Encrypt2(string password, string plainText)
    {
        IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
        IBuffer plainBuffer = CryptographicBuffer.ConvertStringToBinary(plainText, BinaryStringEncoding.Utf8);
        IBuffer iv = WindowsRuntimeBuffer.Create(16);
        SymmetricKeyAlgorithmProvider symProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");
        // create symmetric key from derived password key
        CryptographicKey symmKey = symProvider.CreateSymmetricKey(passwordBuffer);
        // encrypt data buffer using symmetric key and derived salt material
        IBuffer encryptedBuffer = CryptographicEngine.Encrypt(symmKey, plainBuffer, iv);
        string encryptedText = CryptographicBuffer.EncodeToBase64String(encryptedBuffer);
        return encryptedText;
    }
    public static string Decrypt2(string password, string encryptedText)
    {
        IBuffer passwordBuffer = CryptographicBuffer.ConvertStringToBinary(password, BinaryStringEncoding.Utf8);
        IBuffer encryptedBuffer = CryptographicBuffer.DecodeFromBase64String(encryptedText);
        IBuffer iv = WindowsRuntimeBuffer.Create(16);
        SymmetricKeyAlgorithmProvider symProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC_PKCS7");
        // create symmetric key from derived password material
        CryptographicKey symmKey = symProvider.CreateSymmetricKey(passwordBuffer);
        // encrypt data buffer using symmetric key and derived salt material
        IBuffer plainBuffer = CryptographicEngine.Decrypt(symmKey, encryptedBuffer, iv);
        string plainText = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, plainBuffer);
        return plainText;
    }
