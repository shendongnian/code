    public static string DecryptStringFromBase64(string base64String)
    {
        byte[] bytes = Decrypt(Convert.FromBase64String(base64String));
        var utf8 = Encoding.UTF8.GetString(bytes);
        return utf8;
    }
    
    public static byte[] Decrypt(byte[] bytes)
    {
        byte[] iv = new byte[16]; // change
        Array.copy(bytes, iv, 16); // change
        AesManaged algorithm = new AesManaged();
        algorithm.IV = iv; // change
        algorithm.Key = Convert.FromBase64String("KEY");
    
        byte[] ret = null;
        using (var decryptor = algorithm.CreateDecryptor())
        {
            using (MemoryStream msDecrypted = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msDecrypted, decryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(bytes, 16, bytes.Length); // change
                }
                ret = msDecrypted.ToArray();
            }
        }
        return ret;
    }
