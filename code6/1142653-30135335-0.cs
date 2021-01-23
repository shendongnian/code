    // Encrypt the SAML assertion using the service provider's public key.
    // Loading the x509Certificate is not shown but it could be loaded from a .CER file.        
    EncryptedAssertion encryptedAssertion = new EncryptedAssertion(samlAssertion, x509Certificate);
        
    // Add the encrypted assertion to the SAML response.        
    samlResponse.Assertions.Add(encryptedAssertion);
