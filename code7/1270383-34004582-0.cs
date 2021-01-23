    static void EncryptFile(string file, string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        RijndaelManaged AES = new RijndaelManaged();
        AES.KeySize = AES.LegalKeySizes[0].MaxSize;
        AES.BlockSize = AES.LegalBlockSizes[0].MaxSize;
        AES.Padding = PaddingMode.PKCS7;
        //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
        using (var key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000)) // automatically dispose key
        {
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;
        }
        using (FileStream fsCrypt = new FileStream(file + ".enc", FileMode.Create)) // automatically dispose fsCrypt
        {
            //write salt to the beginning of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);
        }
        int bytesToRead = 128 * 1024 * 1024; // 128MB 
        byte[] buffer = new byte[bytesToRead]; // create the array that will be used encrypted
        long fileOffset = 0;
        int read = 0;
        bool allRead = false;
        while (!allRead)
        {
           using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
           {
               fs.Seek(fileOffset, SeekOrigin.Begin); // continue reading from where we were...
               read = fs.Read(buffer, 0, bytesToRead); // read the next chunk
           }
           if (read == 0)
               allRead = true;
           else
               fileOffset += read;
           using (FileStream fsCrypt = new FileStream(file + ".enc", FileMode.Open)) // automatically dispose fsCrypt
           {
               using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
               {
                   cs.Seek(fileOffset, SeekOrigin.End);
                   cs.Write(buffer, 0, read);
               }
            }
        }
