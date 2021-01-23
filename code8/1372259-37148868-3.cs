    public static byte[] Decrypt(byte[] value)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(_password, Encoding.ASCII.GetBytes(_salt));
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                
                using (MemoryStream ms = new MemoryStream(value))
                {
                    byte[] iv = new byte[aes.IV.Length];
                    ms.Read(iv, 0, aes.IV.Length);
                    aes.IV = iv;
                    using (var crypt = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Read))
                       return ReadStream(cs, 0, ms.Length);
                }
            }
        }
