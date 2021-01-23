    private static void Decrypt( string encryptedFilePath, string decryptedOutputLocation)
        {
            var key = "12345678";  //this will be the key you used for encryption
            FileStream fsInput = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read);
            FileStream fsDecrypted = new FileStream(decryptedOutputLocation, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key.ToCharArray());
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key.ToCharArray());
            var desDecryptor = DES.CreateDecryptor();
            CryptoStream cryptostream = new CryptoStream(fsDecrypted, desDecryptor,
                CryptoStreamMode.Write);
            byte[] headerBuffer = new byte[54];
            fsInput.Read(headerBuffer, 0, headerBuffer.Length);
            fsDecrypted.Write(headerBuffer, 0, headerBuffer.Length);
            fsInput.CopyTo(cryptostream);
            cryptostream.Close();
            fsInput.Close();
            fsDecrypted.Close();
        }
