    private RijndaelManaged GetCipher(byte[] key, bool forEncrypt)
    {
        RijndaelManaged rijndaelCipher;
        rijndaelCipher = new RijndaelManaged();
        rijndaelCipher.Mode = CipherMode.CBC;
        rijndaelCipher.Padding = PaddingMode.PKCS7;
        rijndaelCipher.KeySize = 0x80;
        rijndaelCipher.BlockSize = 0x80;
        rijndaelCipher.Key = key;
        if (forEncrypt)
            rijndaelCipher.GenerateIV();
        else
            rijndaelCipher.IV = new byte[16];
        //rijndaelCipher.IV = _imageKey;
        return rijndaelCipher;
    }
    public void DecryptStamp(Stamp stampToDecrypt, string decrpytedStampFilePath)
    {
        RijndaelManaged rijndaelCipher;
        FileStream inputStream = null;
        FileStream outputStream = null;
        CryptoStream encryptSteam = null;
        byte[] block;
        int numberRead;
        ICryptoTransform transform;
        if (!File.Exists(stampToDecrypt.Path))
            throw new FileNotFoundException(stampToDecrypt.Path + " does not exist");
        rijndaelCipher = this.GetCipher(_imageKey, false);
        block = new byte[16];
        try
        {
            inputStream = File.Open(stampToDecrypt.Path, FileMode.Open, FileAccess.Read);
            outputStream = File.Open(decrpytedStampFilePath, FileMode.Create, FileAccess.Write);
            //This line was wrong because rijndaelCipher.IV never filled
            //inputStream.Read(rijndaelCipher.IV, 0, rijndaelCipher.IV.Length); 
            inputStream.Read(block, 0, block.Length);
            rijndaelCipher.IV = block;
            block = new byte[16];
            transform = rijndaelCipher.CreateDecryptor();                     
            encryptSteam = new CryptoStream(outputStream, transform, CryptoStreamMode.Write);
            
            while ((numberRead = inputStream.Read(block, 0, block.Length)) > 0)
            {                
                encryptSteam.Write(block, 0, numberRead);
            }
        }
        finally
        {
            rijndaelCipher.Clear();
            rijndaelCipher.Dispose();
            if (encryptSteam != null)
                encryptSteam.Dispose();
            if (outputStream != null)
                outputStream.Dispose();
            if (inputStream != null)
                inputStream.Dispose();
        }
    }
    public Stamp EncryptStampToStampFolder(string stampFileToEncrpyt)
    {
        Configuration config;
        Stamp stampToEncrypt;
        RijndaelManaged rijndaelCipher;
        string encryptedFilePath;
        if (!File.Exists(stampFileToEncrpyt))
            throw new FileNotFoundException(stampFileToEncrpyt + " does not exist");
        config = Configuration.GetProgramInstance();
        encryptedFilePath = Path.Combine(config.StampFolder, Path.GetFileNameWithoutExtension(stampFileToEncrpyt) + ".stmp");
        stampToEncrypt = new Stamp(Path.GetFileNameWithoutExtension(stampFileToEncrpyt), encryptedFilePath);
        rijndaelCipher = this.GetCipher(_imageKey, true);
        ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
        FileStream inputStream = null;
        FileStream outputStream = null;
        CryptoStream encryptSteam = null;
        byte[] block = new byte[16];
        int numberRead;
        try
        {
            inputStream = File.Open(stampFileToEncrpyt, FileMode.Open, FileAccess.Read);
            outputStream = File.Open(encryptedFilePath, FileMode.Create, FileAccess.Write);
            
            outputStream.Write(rijndaelCipher.IV, 0, IV.Length);
            //This had to be changed so that the IV was not overwitten
            //encryptSteam = new CryptoStream(outputStream, transform, CryptoStreamMode.Write); 
            encryptSteam = new CryptoStream(inputStream, transform, CryptoStreamMode.Read);
            //this line was a problem in the orginal code that caused extra data to be added to the encrypted file
            //encryptSteam.Write(block, 0, block.Length); 
            
            while ((numberRead = encryptSteam.Read(block, 0, block.Length)) > 0)
            {
                outputStream.Write(block, 0, numberRead);
            }
        }
        finally
        {
            rijndaelCipher.Clear();
            rijndaelCipher.Dispose();
            if (encryptSteam != null)
                encryptSteam.Dispose();
            if (outputStream != null)
                outputStream.Dispose();
            if (inputStream != null)
                inputStream.Dispose();
        }
  
        return stampToEncrypt;
    }
    public struct Stamp
    {
        public string Name,
            Path;
        public Stamp(string StampName, string StampPath)
        {
            Name = StampName;
            Path = StampPath;
        }
    }
