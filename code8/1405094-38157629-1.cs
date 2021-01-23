    ...
    var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
    var saltValueBytes = Encoding.UTF8.GetBytes(saltValue);
    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
    string cipherText;
    using (var memoryStream = new MemoryStream())
    {
      using (var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations))
      {
        var keyBytes = password.GetBytes(keySize/8);
        using (var symmetricKey = new RijndaelManaged {Mode = CipherMode.CBC})
        {
          var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
          var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
          cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
          cryptoStream.FlushFinalBlock();
          var cipherTextBytes = memoryStream.ToArray();
          cipherText = Convert.ToBase64String(cipherTextBytes);
        }
      }
    }
    return cipherText;
    ...
