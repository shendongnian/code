    string key = "mysecretkey";
    string secret = "encryptThisMessage";
    byte[] salt = Convert.FromBase64String("zTEeMVPN2eY=");
    
    string crypto = EncryptString(secret, key, salt);
    Console.WriteLine(crypto);
    
    string returnValue = DecryptString(crypto, key, salt);
    Console.WriteLine(returnValue);
...
    public string EncryptString(string plainSourceStringToEncrypt, string passPhrase, byte[] salt)
    {
        //Set up the encryption objects
        using (AesCryptoServiceProvider acsp = GetProvider(passPhrase, salt))
        {
