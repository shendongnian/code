    public void DoEncryption()
    {
        byte[] cipherBytes;
        byte[] textBytes = File.ReadAllBytes(this.filePathToEncrypt);
        using (ICryptoTransform encryptor = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV))
        using (MemoryStream input = new MemoryStream(textBytes))
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
        {
            input.CopyTo(cs);
            cs.FlushFinalBlock();
            cipherBytes = output.ToArray();
        }
        File.WriteAllBytes("EncryptedFile.aes", cipherBytes);
    }
