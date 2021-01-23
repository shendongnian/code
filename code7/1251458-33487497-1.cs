     public static AesCryptoServiceProvider AesEncryptionType(byte[] privateKeyByte, byte[] sharedIVKeyByte)
            {
                var aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = sharedIVKeyByte;
                aes.Key = privateKeyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                return aes;
            }
