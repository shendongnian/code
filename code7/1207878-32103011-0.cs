        private RijndaelManaged GetAesProvider(Stream stm, bool isEncryption)
        {
            byte[] finalKey = GetFinalKey();
            // GetIV either gets salt on encryption and writes it into stm
            // or reads it from stm if it's decryption
            byte[] iv = GetIV(stm, isEncryption);
            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = kAesBlockSizeInBytes * 8;
            aes.IV = iv;
            aes.Key = finalKey;
            aes.Mode = CipherMode.CBC;
            return aes;
        }
        public override Stream GetDecryptionStream(Stream source)
        {
            if (source.Length <= kIVSize)
            {
                return new EmptyStream();
            }
            RijndaelManaged aes = GetAesProvider(source, false);
            ICryptoTransform xform = aes.CreateDecryptor(aes.Key, aes.IV);
            return new CryptoStream(source, xform, CryptoStreamMode.Read);
        }
