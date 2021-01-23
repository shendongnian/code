    public  static string DecryptStringAES(string cipherText)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("plainText");
        String key = "0102030405060708";
        String iv = "1020304050607080";
        if (key == null || key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (iv == null || iv.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] bytearraytodecrypt = Convert.FromBase64String(cipherText);
        AesCryptoServiceProvider keydecrypt = new AesCryptoServiceProvider();
        keydecrypt.BlockSize = 128;
        keydecrypt.KeySize = 128;
        keydecrypt.Key = System.Text.Encoding.UTF8.GetBytes(key);
        keydecrypt.IV = System.Text.Encoding.UTF8.GetBytes(iv);
        keydecrypt.Padding = PaddingMode.PKCS7;
        keydecrypt.Mode = CipherMode.CBC;
        ICryptoTransform crypto1 = keydecrypt.CreateDecryptor(keydecrypt.Key, keydecrypt.IV);
        byte[] returnbytearray = crypto1.TransformFinalBlock(bytearraytodecrypt, 0, bytearraytodecrypt.Length);
        crypto1.Dispose();
        return System.Text.Encoding.UTF8.GetString(returnbytearray);
    }
