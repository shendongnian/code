    public void DoDecrypt()
    {
        byte[] cypherBytes = File.ReadAllBytes(this.filePathToDecrypt);
        byte[] textBytes;
        using (ICryptoTransform decryptor = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV))
        using (MemoryStream input = new MemoryStream(cypherBytes))
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
        {
            cs.CopyTo(output);
            textBytes = output.ToArray();
        }
        File.WriteAllBytes("DecryptedFile.gif", textBytes);
    }
