    public string Encrypt(string strPlainText) {
        byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
        using (ICryptoTransform encryptor = myRijndael.CreateEncryptor())
        using (MemoryStream input = new MemoryStream(strText))
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write)) {
            input.CopyTo(cs);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(output.ToArray());
        }
    }
    public string Decrypt(string encryptedText) {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        using (ICryptoTransform decryptor = myRijndael.CreateDecryptor())
        using (MemoryStream input = new MemoryStream(encryptedBytes))
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read)) {
            cs.CopyTo(output);
            return System.Text.Encoding.UTF8.GetString(output.GetBuffer(), 0, (int)output.Length);
        }
    }
    public static byte[] HexStringToByteArray(string strHex) {
        var r = new byte[strHex.Length / 2];
        for (int i = 0; i < strHex.Length; i += 2) {
            r[i / 2] = byte.Parse(strHex.Substring(i, 2), NumberStyles.HexNumber);
        }
        return r;
    }
