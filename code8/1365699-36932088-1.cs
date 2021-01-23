    static string ComputeSignature(byte[] body, byte[] secret) {
        using (var sha1 = SHA1.Create())
        {
            var key1 = sha1.ComputeHash(body);
            var key2 = key1.Concat(secret).ToArray();
            var key3 = sha1.ComputeHash(key2);
            return Convert.ToBase64String(key3);
        }
    }
