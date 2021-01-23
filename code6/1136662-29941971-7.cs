    public static byte[] EncryptRfc(string plaintext, byte[] key, byte[] iv)
    {
      var key = keyGen.GetBytes(32);
      var iv = keyGen.GetBytes(16);
     
      var cipher = new RijndaelManaged { Key = key, IV = iv };
      ...
     
      return cipherText;
    }
