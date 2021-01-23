    private static string CreateToken(string message, string secret)
    {
        secret = secret ?? "";
        var keyByte = Encoding.ASCII.GetBytes(secret);
        var messageBytes = Encoding.ASCII.GetBytes(message);
        using (var hasher = new HMACSHA256(keyByte))
        {
            var hashmessage = hasher.ComputeHash(messageBytes);
            return Convert.ToBase64String(hashmessage);
        }
    }
