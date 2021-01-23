    using (var aes = new RijndaelManaged { KeySize = 256, Key = fileKey.Key, IV = fileKey.IV })
    {
        using (var encryptedStream = new MemoryStream())
        {
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var originalByteStream = new MemoryStream(file.File.Data))
                    {
                        int data;
                        while ((data = originalByteStream.ReadByte()) != -1)
                            cryptoStream.WriteByte((byte)data);
                    }
                }
            }
            var encryptedBytes = encryptedStream.ToArray();
            return encryptedBytes;
        }
    }
