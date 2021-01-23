    public static string viaRijndael(byte[] input, string key, string iV)
    {
        byte[] decryptedBytes;
        using (Rijndael rijCrypt = Rijndael.Create())
        {
            rijCrypt.Key = System.Text.Encoding.UTF8.GetBytes(Tools.GetMD5Hash(Tools.GetMD5Hash(key))); 
            rijCrypt.IV = System.Text.Encoding.UTF8.GetBytes(Tools.GetMD5Hash(Tools.GetMD5Hash(key)).Substring(0, 16));
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, rijCrypt.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(input, 0, input.Length); 
                }
                decrpytedBytes = ms.ToArray();
            }
        }
        return System.Text.Encoding.UTF8.GetString(decryptedBytes);
    }
