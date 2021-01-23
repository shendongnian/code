    internal static byte[] AesEncryptor(byte[] key, byte[] iv, byte[] payload)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                var encryptor = aesAlg.CreateEncryptor(key, iv);
                var encrypted = encryptor.TransformFinalBlock(payload, 0, payload.Length);
                return iv.Concat(encrypted).ToArray();
            }
        }
