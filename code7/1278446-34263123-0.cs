    byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
    byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };
    string path = @"C:\path\to.file";
    
    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    
    // Encryption and serialization
    using (var fStream = new FileStream(path, FileMode.Create, FileAccess.Write))
    using (var cryptoStream = new CryptoStream(fStream , des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
    {
        BinaryFormatter serializer = new BinaryFormatter();
    
        // This is where you serialize your data
        serializer.Serialize(cryptoStream, yourData);
    }
    
    
    // Decryption
    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    using (var cryptoStream = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
    {
        BinaryFormatter serializer = new BinaryFormatter();
    
        // Deserialize your data from file
        yourDataType yourData = (yourDataType)serializer.Deserialize(cryptoStream);
    }
