    // The initialization vector MUST be changed every time a plaintext is encrypted.
    // The initialization vector MUST NOT be reused a second time.
    // The initialization vector CAN be saved along the ciphertext.
    // See https://en.wikipedia.org/wiki/Initialization_vector for more information.
    var iv = Convert.FromBase64String("9iAwvNddQvAAfLSJb+JG1A==");
    
    // The encryption key CAN be the same for every encryption.
    // The encryption key MUST NOT be saved along the ciphertext.
    var key = Convert.FromBase64String("UN8/gxM+6fGD7CdAGLhgnrF0S35qQ88p+Sr9k1tzKpM=");
    
    using (var algorithm = new AesManaged())
    {
        algorithm.IV = iv;
        algorithm.Key = key;
        
        byte[] ciphertext;
        
        using (var memoryStream = new MemoryStream())
        {
            using (var encryptor = algorithm.CreateEncryptor())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write("MySuperSecretHighScore");
                    }
                }
            }
            
            ciphertext = memoryStream.ToArray();
        }
        
        // Now you can serialize the ciphertext however you like.
        // Do remember to tag along the initialization vector,
        // otherwise you'll never be able to decrypt it.
        
        // In a real world implementation you should set algorithm.IV,
        // algorithm.Key and ciphertext, since this is an example we're
        // re-using the existing variables.
        using (var memoryStream = new MemoryStream(ciphertext))
        {
            using (var decryptor = algorithm.CreateDecryptor())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        // You have your "MySuperSecretHighScore" back.
                        var plaintext = streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
