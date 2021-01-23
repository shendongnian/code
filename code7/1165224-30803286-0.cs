    public string utf16_encrypt(string input)
    {
        string sPlainText = input;
        string output;
        if (!string.IsNullOrEmpty(sPlainText))
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, this.encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(enc.GetBytes(sPlainText), 0, sPlainText.Length);
            cryptoStream.FlushFinalBlock();
            output = Convert.ToBase64String(memoryStream.ToArray());
            memoryStream.Close();
            cryptoStream.Close();
            return output;
        }
        else
            return null;
    }
