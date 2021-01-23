    static public Tuple<byte[], byte[]> EncryptAES(byte[] toEncryptAES, RSAParameters RSAPublicKey)
    {
        byte[] encryptedAES = null;
        byte[] encryptedRSA = null;
        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Mode = CipherMode.CBC;
                AES.GenerateIV();
                AES.GenerateKey();
                encryptedRSA = RSAEncrypt(AES.Key, RSAPublicKey);
                ms.Write(AES.IV, 0, AES.KeySize); //Move the write here.
                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(toEncryptAES, 0, toEncryptAES.Length);
                    cs.Close();
                }
                encryptedAES = ms.ToArray();
            }
        }
        return new Tuple<byte[], byte[]>(encryptedAES, encryptedRSA);
    }
