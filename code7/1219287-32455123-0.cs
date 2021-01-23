    byte[] r;
    using (var sMemory = new MemoryStream())
    {
        using (var sCrypt = new CryptoStream(sMemory, encryptor, CryptoStreamMode.Write))
        {
            using (var sWriter = new StreamWriter(sCrypt))
            {
                sWriter.Write(text);
            }
        }
        r = sMemory.ToArray();
    }
