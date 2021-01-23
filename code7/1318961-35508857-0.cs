    public static byte[] HmacSha1Sign(byte[] keyBytes, string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        MacAlgorithmProvider objMacProv = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
        CryptographicKey hmacKey = objMacProv.CreateKey(keyBytes.AsBuffer());
        IBuffer buffHMAC = CryptographicEngine.Sign(hmacKey, messageBytes.AsBuffer());
        return buffHMAC.ToArray();
    }
