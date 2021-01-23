    public CARequestModel CertRequest(string subjectDN)
    {
        var name = new X509Name(subjectDN);
        var rsaKeyPairGenerator = new RsaKeyPairGenerator();
        
        rsaKeyPairGenerator.Init(
            new KeyGenerationParameters(new SecureRandom(
                    new CryptoApiRandomGenerator()), _appSettings.PRIVATE_KEY_LENGHT));
    
        // Generate key pair.
        var keyPair = rsaKeyPairGenerator.GenerateKeyPair();
        
        // Get the private key.
        var privateKey = keyPair.Private;
        
        // Get the public key.
        var publicKey = keyPair.Public;
    
        // Set the key usage scope.
        var keyUsage = new KeyUsage(KeyUsage.DigitalSignature);
        var extensionsGenerator = new X509ExtensionsGenerator();
    
        extensionsGenerator.AddExtension(X509Extensions.KeyUsage, true, keyUsage);
    
        var attribute = new AttributeX509(
            PkcsObjectIdentifiers.Pkcs9AtExtensionRequest, new DerSet(extensionsGenerator.Generate()));
    
        // Create the certificate request
        var csr = new Pkcs10CertificationRequest("SHA1WITHRSA", name, publicKey, new DerSet(attribute), privateKey);
        
        // Get it as DER, because then I have to submit it to the MS CA server.
        var csrBytes = csr.GetDerEncoded();
    
        // Return the Request and private key
        return
            new CARequestModel
            {
                Request = Convert.ToBase64String(csrBytes),
                PrivateKey = privateKey
            };
    }
