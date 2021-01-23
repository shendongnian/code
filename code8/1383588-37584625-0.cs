        byte[] privateKeyBlob;
        CspParameters cp = new CspParameters(24);
        RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey;
        privateKeyBlob = csp.ExportCspBlob(true);
        csp = new RSACryptoServiceProvider(cp);
        csp.ImportCspBlob(privateKeyBlob); 
        // Sign the hash
        return csp.SignHash(hashchain, CryptoConfig.MapNameToOID("SHA-512"));
