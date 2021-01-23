    static private string CalculateSignature(String stringToSign, String key)
    {
        byte[] key_byte = Encoding.UTF8.GetBytes(key);
        byte[] stringToSign_byte = Encoding.UTF8.GetBytes(stringToSign);
        //Check Signature
        HMACSHA256 hmac = new HMACSHA256(key_byte);
        byte[] hashValue = hmac.ComputeHash(stringToSign_byte);
        return BitConverter.ToString(hashValue).Replace("-", "");
    }
