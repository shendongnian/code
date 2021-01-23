    public Stream DecryptFile(string inputFile)//, string outputFile)
    {
        string password = @"mykey"; // Your Key Here
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] key = UE.GetBytes(password);
        using(var fsCrypt = new FileStream(inputFile, FileMode.Open)
        {
            RijndaelManaged RMCrypto = new RijndaelManaged();
            using(CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read))
            {
                StreamReader sr = new StreamReader(cs);
                Stream s = sr.BaseStream;
                return s;
            }
        }
    }
