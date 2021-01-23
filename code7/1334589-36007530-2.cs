    public string Encrypt(string strPlainText) {
        byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
        using (ICryptoTransform encryptor = myRijndael.CreateEncryptor())
        using (MemoryStream output = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write)) {
            cs.Write(strText, 0, strText.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(output.ToArray());
        }
    }
