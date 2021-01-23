    public static byte[] Encrypt(byte[] value)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(_password, Encoding.ASCII.GetBytes(_salt));
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.GenerateIV();
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                using (var crypt = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                using (BinaryWriter bw = new BinaryWriter(cs))
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    bw.Write(value);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }
