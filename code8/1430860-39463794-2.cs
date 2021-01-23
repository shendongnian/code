    // Generate private and public keys (use any asymmetric crypto/key size you want)
    RSACryptoServiceProvider rsaKeys = new RSACryptoServiceProvider();
    var privateXmlKeys = rsaKeys.ToXmlString(true);
    var publicXmlKeys = rsaKeys.ToXmlString(false);
    
    // Make the request for the json data from the server, and also pass along the public xml keys encoded as base64 
    var response = await http.GetAsync(new Uri(String.Format("https://example.com/data?id=777&pk=\"{0}\"", Convert.ToBase64String(Encoding.ASCII.GetBytes(publicXmlKeys)))));
    var encryptedJsonBytes = await response.Content.ReadAsByteArrayAsync();
    
    // Decrypt the bytes using the private key generated earlier
    RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider();
    rsaDecrypt.FromXmlString(privateXmlKeys);
    byte[] decryptedBytes = rsaDecrypt.Decrypt(encryptedJsonBytes, false);
    
    // Now change from bytes to string
    string jsonString = Encoding.ASCII.GetString(decryptedBytes);
    // TODO: For extra validation, parse json, get the public key out that the server
    //       had used to encrypt, and compare with the "pk" you sent "publicXmlKeys",
    //       if these values do not match there was an attack.
