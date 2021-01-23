    public static string Encrypt(this string text, string key)
    {
        var keyAes = Encoding.UTF8.GetBytes(key);
        var buffer = Encoding.UTF8.GetBytes(text);
        using (var aes = Aes.Create())
        {
            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));
            aes.Key = keyAes;
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var resultStream = new MemoryStream())
            {
                using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                using (var plainStream = new MemoryStream(buffer))
                {
                    plainStream.CopyTo(aesStream);
                }
                var result = resultStream.ToArray();
                var combined = new byte[aes.IV.Length + result.Length];
                Array.ConstrainedCopy(aes.IV, 0, combined, 0, aes.IV.Length);
                Array.ConstrainedCopy(result, 0, combined, aes.IV.Length, result.Length);
                return Convert.ToBase64String(combined);
            }
        }
    }
    public static string Decrypt(this string encryptedText, string key)
    {
        var combined = Convert.FromBase64String(encryptedText);
        var buffer = new byte[combined.Length];
        var keyAes = Encoding.UTF8.GetBytes(key);
        using (var aes = Aes.Create())
        {
            if (aes == null)
                throw new ArgumentException("Parameter must not be null.", nameof(aes));
            aes.Key = keyAes;
            var iv = new byte[aes.IV.Length];
            var ciphertext = new byte[buffer.Length - iv.Length];
            Array.ConstrainedCopy(combined, 0, iv, 0, iv.Length);
            Array.ConstrainedCopy(combined, iv.Length, ciphertext, 0, ciphertext.Length);
            aes.IV = iv;
            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var resultStream = new MemoryStream())
            {
                using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                using (var plainStream = new MemoryStream(ciphertext))
                {
                    plainStream.CopyTo(aesStream);
                }
                return Encoding.UTF8.GetString(resultStream.ToArray());
            }
        }
    }
