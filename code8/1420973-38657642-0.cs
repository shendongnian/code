    public static string CreateSignature(string message, string key)
    {
        var encoding = new System.Text.UTF8Encoding();
        byte[] keyByte = encoding.GetBytes(key);
        byte[] messageBytes = encoding.GetBytes(message);
        using (var hmacsha1 = new HMACSHA1(keyByte, false))
        {
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
			string hashstring = BitConverter.ToString(hmacsha1.ComputeHash(messageBytes)).Replace("-","").ToLower();
            return Convert.ToBase64String(encoding.GetBytes(hashstring));
        }
    }
