    using (MemoryStream memoryStream = new MemoryStream())
    {
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, tdes.CreateEncryptor(keyArray, keyArray), CryptoStreamMode.Write))
        {
            using (StreamWriter writer = new StreamWriter(cryptoStream))
            {
                writer.Write(toEncrypt);
            }
            byte[] buffer = memoryStream.ToArray();
            retvalue = BitConverter.ToString(buffer, 0, buffer.Length).Replace("-", "");
        }
    }
