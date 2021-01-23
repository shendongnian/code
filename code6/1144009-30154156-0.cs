           public byte[] Decode(byte[] data)
        {
            ICryptoTransform decryptor = rc2.CreateDecryptor(rc2.Key,rc2.IV);
            byte[] decrypted = new byte[data.Length];
            using (MemoryStream msDecrypt = new MemoryStream(data))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                   csDecrypt.Read(decrypted, 0, data.Length);
                }
            }
            return decrypted;
        }
