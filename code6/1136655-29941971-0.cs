    public static byte[] EncryptRfc(byte[] plainText, string password, byte[] salt)
    {
      var keyGen = new Rfc2898DeriveBytes(password, salt);
      var key = keyGen.GetBytes(32);
      var iv = keyGen.GetBytes(16);
     
      var cipher = new RijndaelManaged { Key = key, IV = iv };
     
      byte[] cipherText;
      using (var encryptor = cipher.CreateEncryptor()) {
        using (var ms = new MemoryStream()) {
          using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();
            cipherText = ms.ToArray();
          }
        }
      }
      return cipherText;
    }
