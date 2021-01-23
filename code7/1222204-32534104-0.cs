    string salt = // get salt from db
    string password = // get password from user
    MD5 md5 = new MD5CryptoServiceProvider();
    
    // Create md5 hash of salt
    byte[] saltBytes = Encoding.Default.GetBytes(salt);
    byte[] saltHashBytes = md5.ComputeHash(salt);
    string saltHash = System.BitConverter.ToString(saltHashBytes);
    
    // Create your md5(password + md5(salt)) hash
    byte[] passwordBytes = Encoding.Default.GetBytes(password + saltHash);
    byte[] passwordHashBytes = md5.ComputeHash(salt);
    string passwordHash = System.BitConverter.ToString(passwordHashBytes);
