    public string Encrypt(string strPlainText) {
        byte[] strText = System.Text.Encoding.UTF8.GetBytes(strPlainText);
        using (ICryptoTransform encryptor = myRijndael.CreateEncryptor())
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write)) {
            cs.Write(strText, 0, strText.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(output.GetBuffer(), 0, (int)output.Length);
        }
    }
