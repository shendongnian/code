    static public byte[] DecryptAES(byte[] toDecryptAES, byte[] AESKeyAndIV, RSAParameters RSAPrivateKey)
    {
        byte[] AESKey = RSADecrypt(AESKeyAndIV, RSAPrivateKey);
        using (MemoryStream source = new MemoryStream(toDecryptAES))
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Key = AESKey;
                var iv = ReadFully(source, AES.KeySize);
                AES.IV = iv;
                AES.Mode = CipherMode.CBC;
                using (var cs = new CryptoStream(source, AES.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using(var dest = new MemoryStream())
                    {
                        cs.CopyTo(dest);
                        return dest.ToArray();
                    }
                }
            }
        }
    }
