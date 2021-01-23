    static void EncryptFile(string file, string password)
    {
        // a static salt is not a good idea, a random salt is required
        byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        RijndaelManaged AES = new RijndaelManaged();
        AES.KeySize = AES.LegalKeySizes[0].MaxSize;
        AES.BlockSize = AES.LegalBlockSizes[0].MaxSize;
        AES.Mode = CipherMode.CFB;
        // CFB doesn't require padding
        AES.Padding = PaddingMode.None;
        SetKey(AES, password, salt);
        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
            using (FileStream fsCrypt = new FileStream(file + ".ecc", FileMode.Create))
            {
                fsCrypt.Write(salt, 0, salt.Length);
                // cryptostream itself doesn't hold resources, so no need for using keyword
                CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
                // should be a constant
                int bytesToRead = 128 * 1024 * 1024; // 128 MiB 
                byte[] buffer = new byte[bytesToRead];
                while (true)
                {
                    // read the next chunk
                    int read = fs.Read(buffer, 0, bytesToRead);
                    if (read == 0)
                        break;
                    cs.Write(buffer, 0, read);
                }
            }
        }
    }
    private static void SetKey(RijndaelManaged AES, string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        // not required, password is already hashed by Rfc2898DeriveBytes (PBKDF2)
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        // 1000 is too low a number, use a constant or a configurable option
        using (var key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000))
        {
            // using PBKDF2 for a number of bytes > internal hash size is not efficient
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
        }
    }
    public static void DecryptFile(string file, string password)
    {
        using (FileStream fsCrypt = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
            byte[] salt = new byte[8];
            for (int i = 0; i < salt.Length; i++)
            {
                int b = fsCrypt.ReadByte();
                if (b == -1)
                {
                    throw new EndOfStreamException();
                }
                salt[i] = (byte)b;
            }
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = AES.LegalKeySizes[0].MaxSize;
            AES.BlockSize = AES.LegalBlockSizes[0].MaxSize;
            AES.Mode = CipherMode.CFB;
            // CFB doesn't require padding
            AES.Padding = PaddingMode.None;
            SetKey(AES, password, salt);
            // cryptostream itself doesn't hold resources, so no need for using keyword
            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            string extension = System.IO.Path.GetExtension(file);
            string result = file.Substring(0, file.Length - extension.Length) + ".dec";
            using (FileStream fs = new FileStream(result, FileMode.Create))
            {
                // should be a constant
                int bytesToRead = 128 * 1024 * 1024; // 128 MiB 
                byte[] buffer = new byte[bytesToRead];
                while (true)
                {
                    // read the next chunk
                    int read = cs.Read(buffer, 0, bytesToRead);
                    if (read == 0)
                        break;
                    fs.Write(buffer, 0, read);
                }
            }
        }
    }
