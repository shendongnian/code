    public static byte[] EncryptData(string pass, byte[] salt, byte[] encryptedPrivateKey, byte[] targetPublicKey,
        byte[] iv, byte[] data)
    {
        using (var rfc = new Rfc2898DeriveBytes(pass, salt, IterationCount))
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = AesKeySize;
                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = iv;
    
                using (var dec = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(encryptedPrivateKey))
                    {
                        using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                        {
                            var privKey = new byte[RsaKeySize];
                            cs.Read(privKey, 0, privKey.Length);
                            return RsaEncrypt(targetPublicKey, data);
                        }
                    }
                }
            }
        }
    }
    public static byte[] DecryptData(string pass, byte[] salt, byte[] encryptedPrivateKey, byte[] iv, byte[] data)
    {
        using (var rfc = new Rfc2898DeriveBytes(pass, salt, IterationCount))
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = AesKeySize;
                aes.Key = rfc.GetBytes(aes.KeySize/8);
                aes.IV = iv;
    
                using (var dec = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(encryptedPrivateKey))
                    {
                        using (var cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                        {
                            var privKey = new byte[RsaKeySize];
                            cs.Read(privKey, 0, privKey.Length);
                            return RsaDecrypt(privKey, data);
                        }
                    }
                }
            }
        }
    }
