    -- Generate salt
    SET @salt = UNHEX(SHA2(UUID(), 256));
    -- Create user and hash password with salt
    INSERT INTO users (username, password_salt, password_hash)
      VALUES ('ajay', @salt, UNHEX(SHA2(CONCAT('ajay123', @salt), 256)));
---
    public static byte[] ComputeHash(string salt,string password)
    {
      byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
      byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
      byte[] concat = new byte[plainTextBytes.Length + saltBytes .Length];
      System.Buffer.BlockCopy(plainTextBytes, 0, concat, 0, plainTextBytes.Length);
      System.Buffer.BlockCopy(saltBytes , 0, concat, plainTextBytes.Length, saltBytes .Length);
      SHA256Managed hash = new SHA256Managed();
      byte[] tHashBytes = hash.ComputeHash(concat);
      return tHashBytes;
    }
