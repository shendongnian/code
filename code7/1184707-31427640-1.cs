    byte[] byteArray = Encoding.UTF8.GetBytes(sourceText);
    Byte[] newByteArray;
    using (MemoryStream plainText = new MemoryStream(byteArray))
    {
        using (MemoryStream encryptedData = new MemoryStream())
        {
            SharpAESCrypt.Encrypt(password, plainText, encryptedData);
            newByteArray = encryptedData.ToArray();
        }
    }
    EncryptedTB.Text = Convert.ToBase64String(newByteArray);
