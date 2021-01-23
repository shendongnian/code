    public static string Encrypt(string pDataToEncrypt)
    {
    
        RijndaelManaged myRijndael = new RijndaelManaged();
    
        ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);
    
        MemoryStream msEncrypt = new MemoryStream();
        CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor,CryptoStreamMode.Write);
    
        byte[] toEncrypt = Encoding.UTF8.GetBytes(pDataToEncrypt);
    
        csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
        csEncrypt.FlushFinalBlock();
    
        return Convert.ToBase64String(msEncrypt.GetBuffer(), 0, (int)msEncrypt.Length);
    }
    
    public static string Decrypt(string pDataToDecrypt)
    {
        RijndaelManaged myRijndael = new RijndaelManaged();
        
        byte[] fromEncrypt = Convert.FromBase64String(pDataToDecrypt);
        ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);
    
        MemoryStream msDecrypt = new MemoryStream(fromEncrypt, 0, fromEncrypt.Length);
        CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
    	
    	byte[] plainTextBytes = new byte[fromEncrypt.Length];
    	int decryptedByteCount = csDecrypt.Read(plainTextBytes, 0, plainTextBytes.Length);
    	
    	return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    }
