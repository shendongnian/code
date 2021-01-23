    static byte[] hmacSHA256(String data, String key)
    {
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(key)))
        {
            return hmac.ComputeHash(Encoding.ASCII.GetBytes(data));
        }
    }
