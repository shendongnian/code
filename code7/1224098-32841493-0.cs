      public string Sign(string privateKey, string data)
      {
           _rsaProvider.ImportCspBlob(Convert.FromBase64String(privateKey));
           //// Write the message to a byte array using UTF8 as the encoding.
           var encoder = new UTF8Encoding();
           byte[] byteData = encoder.GetBytes(data);
           //// Sign the data, using SHA512 as the hashing algorithm 
           byte[] encryptedBytes = _rsaProvider.SignData(byteData, new SHA1CryptoServiceProvider());
           return Convert.ToBase64String(encryptedBytes);
       }
