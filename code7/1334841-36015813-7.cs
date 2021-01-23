    public static string Encrypt(string password, string plainText)
    {
        using (var aes = new AesManaged())
        {
            aes.Key = Encoding.UTF8.GetBytes(password);
            aes.IV = new byte[16];
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            byte[] plainBuffer = Encoding.UTF8.GetBytes(plainText);
            using (MemoryStream input = new MemoryStream(plainBuffer))
            using (MemoryStream output = new MemoryStream())
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
            {
                input.CopyTo(cs);
                cs.FlushFinalBlock();
                string encryptedText = Convert.ToBase64String(output.GetBuffer(), 0, (int)output.Length);
                return encryptedText;
            }
        }
    }
    public static string Decrypt(string password, string encryptedText)
    {
        using (var aes = new AesManaged())
        {
            aes.Key = Encoding.UTF8.GetBytes(password);
            aes.IV = new byte[16];
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            byte[] encryptedBuffer = Convert.FromBase64String(encryptedText);
            using (MemoryStream input = new MemoryStream(encryptedBuffer))
            using (MemoryStream output = new MemoryStream())
            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            using (CryptoStream cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
            {
                cs.CopyTo(output);
                string plainText = Encoding.UTF8.GetString(output.GetBuffer(), 0, (int)output.Length);
                return plainText;
            }
        }
    }
