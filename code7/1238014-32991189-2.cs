    string salt = "D4UFUd6U"; // get salt from db
    string password = "test!";// get password from user
    MD5 md5 = new MD5CryptoServiceProvider();
    // Create md5 hash of salt
    byte[] saltBytes = Encoding.Default.GetBytes(salt);
    byte[] saltHashBytes = md5.ComputeHash(GenerateStreamFromString(salt));
    string saltHash = System.BitConverter.ToString(saltHashBytes);
    
    // Create your md5(password + md5(salt)) hash
    byte[] passwordBytes = Encoding.Default.GetBytes(password + saltHash);
    byte[] passwordHashBytes = md5.ComputeHash(GenerateStreamFromString(salt));
    string passwordHash = BitConverter.ToString(passwordHashBytes);
