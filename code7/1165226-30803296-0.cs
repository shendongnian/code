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
        
        return "Invalid Input"; //Or whatever message you want to pass back to the user/code. 
