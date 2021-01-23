    public static string Encrypt(string password, string strPlainText)
    {
        using (var aes = new AesManaged())
        {
            aes.Key = Encoding.UTF8.GetBytes(password);
            aes.IV = new byte[16];
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            byte[] strText = Encoding.UTF8.GetBytes(strPlainText);
            using (MemoryStream input = new MemoryStream(strText))
            using (MemoryStream output = new MemoryStream())
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
            {
                input.CopyTo(cs);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(output.GetBuffer(), 0, (int)output.Length);
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
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            using (MemoryStream input = new MemoryStream(encryptedBytes))
            using (MemoryStream output = new MemoryStream())
            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            using (CryptoStream cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
            {
                cs.CopyTo(output);
                return Encoding.UTF8.GetString(output.GetBuffer(), 0, (int)output.Length);
            }
        }
    }
