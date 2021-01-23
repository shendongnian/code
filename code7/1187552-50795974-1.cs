    internal static byte[] AesDecryptor(byte[] key, byte[] iv, byte[] payload)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                return decryptor.TransformFinalBlock(payload, 0, payload.Length);
            }
        }
