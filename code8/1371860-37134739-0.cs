    public static string Decrypt(string encrypted)
    {
        string secretKey = "1234567890123456";
        byte[] keyBytes = Encoding.UTF8.GetBytes(secretKey);
        byte[] ivBytes = null;
    
        DESCryptoServiceProvider csp = new DESCryptoServiceProvider();
        ICryptoTransform dec = csp.CreateDecryptor(keyBytes, ivBytes);
    
        byte[] cipherText = Encoding.UTF8.GetBytes(encrypted);
        string plainText = null;
    
        using (MemoryStream ms = new MemoryStream(cipherText, false))
        {
            ms.Position = 0;
            using (CryptoStream cryptStrm = new CryptoStream(ms, dec, CryptoStreamMode.Read))
            {
                StreamReader rdr = new StreamReader(cryptStrm);
                    plainText = rdr.ReadToEnd();
            }
        }
    
        return plainText;
    }
