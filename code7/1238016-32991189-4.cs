    string salt = "D4UFUd6U"; // get salt from db
    string password = "test!";// get password from user
    MD5 md5 = new MD5CryptoServiceProvider();
    // Create md5 hash of salt
    byte[] saltBytes = Encoding.Default.GetBytes(salt);
    byte[] saltHashBytes;
    using( Stream saltStream = GenerateStreamFromString(salt))
    {
        salteHashBytes = md5.ComputeHash(saltStream);
    }
    string saltHash = System.BitConverter.ToString(saltHashBytes);
    
    // Create your md5(password + md5(salt)) hash
    byte[] passwordBytes = Encoding.Default.GetBytes(password + saltHash);
    byte[] passwordHashBytes;
    using( Stream saltStream = GenerateStreamFromString(salt))
    {
        passwordHashBytes = md5.ComputeHash(saltStream);
    }
    string passwordHash = BitConverter.ToString(passwordHashBytes);
