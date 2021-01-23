    public static string GenerateAccessToken(string uniqueId) // generates a unique, random, and alphanumeric token
    {
        const string availableChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        using (var generator = new RNGCryptoServiceProvider())
        {
            var bytes = new byte[16];
            generator.GetBytes(bytes);
            var chars = bytes.Select(b => availableChars[b % availableChars.Length]);
            var token = new string(chars.ToArray());
            return uniqueId + token;
        }
    }
