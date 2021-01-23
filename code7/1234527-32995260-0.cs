    public static string Encrypt(string data, string pKey)
    {
        TripleDESCryptoServiceProvider cryptor = new TripleDESCryptoServiceProvider();
        byte[] array = null;
        cryptor.Key = pKey;
        cryptor.Mode = CipherMode.ECB;
        ICryptoTransform encrypt = cryptor.CreateEncryptor();
        array = ASCIIEncoding.ASCII.GetBytes(data);
        string retVal = "";
        retVal = Convert.ToBase64String(encrypt.TransformFinalBlock(array, 0, array.Length));
        return retVal;
    }
