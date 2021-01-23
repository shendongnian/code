        byte[] byteArray = Encoding.ASCII.GetBytes(sourceText);
        byteArray.Select(x => x.ToString("x"));
        Byte[] newByteArray;
        using (MemoryStream plainText = new MemoryStream(byteArray))
        {
            using (MemoryStream encryptedData = new MemoryStream())
            {
                SharpAESCrypt.Encrypt(password, plainText, encryptedData);
                newByteArray = encryptedData.ToArray();
                newByteArray.Select(x => x.ToString("x"));
            }
        }
