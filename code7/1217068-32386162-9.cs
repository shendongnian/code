    public string CallHmacSha256OnSignature(string toSign, string hashKey)
    {
        var result = "";
    
        // UTF-8-encoded signature string
        var utf8 = BinaryStringEncoding.Utf8;
        var msgMaterial = CryptographicBuffer.ConvertStringToBinary(toSign, utf8);
    
        // key
        var keyMaterial = CryptographicBuffer.DecodeFromBase64String(hashKey);
    
        // make the HMAC-SHA256 algorithm
        var alg = MacAlgorithmNames.HmacSha256;
        var objMacProv = MacAlgorithmProvider.OpenAlgorithm(alg);
        CryptographicHash hash = objMacProv.CreateHash(keyMaterial);
    
        // call the HMAC-SHA256 algorithm
        hash.Append(msgMaterial);
        IBuffer hashMsg = hash.GetValueAndReset();
    
        // retrieve the result!
        result = Convert.ToBase64String(hashMsg.ToArray());
        return result;
    }
