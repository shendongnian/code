    public string GetEncodedSignature(string toSign, string hashKey)
    {
        // UTF-8-encoded signature string
        var utf8 = BinaryStringEncoding.Utf8;
        var msgBuffer = CryptographicBuffer.ConvertStringToBinary(toSign, utf8);
        // key
        var keyBuffer = CryptographicBuffer.DecodeFromBase64String(hashKey);
        // make the HMAC-SHA256 algorithm
        var alg = MacAlgorithmNames.HmacSha256;
        var objMacProv = MacAlgorithmProvider.OpenAlgorithm(alg);
        CryptographicHash hash = objMacProv.CreateHash(keyBuffer);
        // call the HMAC-SHA256 algorithm
        hash.Append(msgBuffer);
        IBuffer hashMsg = hash.GetValueAndReset();
        // retrieve the result!
        var result = Convert.ToBase64String(hashMsg.ToArray());
        return result;
    }
