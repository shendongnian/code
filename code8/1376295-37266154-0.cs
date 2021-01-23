    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
    {
        // your code
        byte[]  plainBytes = Encoding.UTF8.Getbytes(plainText);
        byte[] encrypted;
        Aes aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.Key = IV;
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        using(MemoryStream ms = new MemoryStream())
        {
            using(CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
        csEncrypt.Write(plainBytes,0, plainBytes.Length );
                 csEncrypt.FlushFinalBlock();
                 return msEncrypt.ToArray();
            }
        }
    }
