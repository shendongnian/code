    private void Transform(string inputFileName, string outputFileName, bool encrypt)
    {
        using (var source = new FileStream(inputFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var destination = new FileStream(outputFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
        {
            ICryptoTransform cryptoTransform;
            if (encrypt)
            {
                //put the IV unencrypted in the front of the string
                destination.Write(AES.IV, 0, AES.BlockSize / 8);
                cryptoTransform = AES.CreateEncryptor(AES.Key, AES.IV);
            }
            else
            {
                byte[] bytes = new byte[AES.BlockSize / 8];
                source.Read(bytes, 0, bytes.Length);
                AES.IV = bytes;
                cryptoTransform = AES.CreateDecryptor(AES.Key, AES.IV);
            }
            Transform(source, destination, cryptoTransform, encrypt);
        }
    }
    private static void Transform(Stream inputStream, Stream outputStream, ICryptoTransform transform, bool encrypt)
    {
        using (var cryptoStream = new CryptoStream(encrypt ? outputStream : inputStream, transform, encrypt ? CryptoStreamMode.Write : CryptoStreamMode.Read))
        {
            //inputStream.Position = AES.BlockSize/8 + 1; CryptographicException : Length of the data to decrypt is invalid.
            //inputStream.Position = AES.BlockSize/8; CryptographicException : Padding is invalid and cannot be removed.
            if (encrypt)
            {
                inputStream.CopyTo(cryptoStream);
                // Not needed. Done by the Dispose()
                //cryptoStream.FlushFinalBlock();
            }
            else
            {
                cryptoStream.CopyTo(outputStream);
            }
        }
    }
