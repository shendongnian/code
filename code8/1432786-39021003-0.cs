    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        try
        {
            byte[] byteArray = Convert.FromBase64String(txtOutput.Text.Trim());
            Byte[] newByteArray;
            string output = "";
            using (MemoryStream plainText = new MemoryStream(byteArray))
            {
                using (MemoryStream encryptedData = new MemoryStream())
                {
                    SharpAESCrypt.SharpAESCrypt.Decrypt("ABCD@123", txtOutput.Text.Trim(), output);
                    newByteArray = encryptedData.ToArray();
                }
            }
            string FinalText = System.Text.Encoding.UTF8.GetString(byteArray);
        }
        catch (Exception ex)
        {
        }
    }
