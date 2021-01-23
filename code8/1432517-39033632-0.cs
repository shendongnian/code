            public string AES_DEC(string text, string password)
        {
            RijndaelManaged aes256 = new RijndaelManaged();
            aes256.KeySize = 128;
            aes256.BlockSize = 128;
            aes256.Padding = PaddingMode.PKCS7;
            aes256.Mode = CipherMode.ECB;
            aes256.Key = Encoding.UTF8.GetBytes(password);
            aes256.GenerateIV();
            
            byte[] encryptedData = Convert.FromBase64String(text);
            ICryptoTransform transform = aes256.CreateDecryptor();
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            
            return Encoding.UTF8.GetString(plainText);
        }
