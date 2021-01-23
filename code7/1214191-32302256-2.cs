        private byte[] encrypt(byte[] originalPlaintextBytes)
        {
            using (SymmetricAlgorithm algorithm = AesCryptoServiceProvider.Create())
            {
                algorithm.GenerateKey();
                algorithm.GenerateIV();
                byte[] iv = algorithm.IV;
                byte[] key = algorithm.Key;
                using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
                {
                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, encryptor,CryptoStreamMode.Write))
                    {
                        BinaryWriter bw = new BinaryWriter(ms);
                        bw.Write(iv);
                        cs.Write(originalPlaintextBytes, 0, originalPlaintextBytes.Length);
                        return ms.ToArray();
                    }
                }
            }
        }
