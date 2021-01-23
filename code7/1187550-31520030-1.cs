    //used for the blob stream from Azure
    using (var encryptedStream = new MemoryStream(encryptedBytes))
    {
        //stream where decrypted contents will be stored
        using (var decryptedStream = new MemoryStream())
        {
            using (var aes = new RijndaelManaged { KeySize = 256, Key = blobKey.Key, IV = blobKey.IV })
            {
                using (var decryptor = aes.CreateDecryptor())
                {
                    //decrypt stream and write it to parent stream
                    using (var cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read))
                    {
                        int data;
                        while ((data = cryptoStream.ReadByte()) != -1)
                            decryptedStream.WriteByte((byte)data);
                    }
                }
            }
            //reset position in prep for reading
            decryptedStream.Position = 0;
            return decryptedStream.ConvertToByteArray();
        }
    }
