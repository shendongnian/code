    RSACryptoServiceProvider tempRcsp = (RSACryptoServiceProvider)DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)keyPair.Private);
      RSACryptoServiceProvider rcsp = new RSACryptoServiceProvider(new CspParameters(1, "Microsoft Strong Cryptographic Provider", new Guid().ToString(), new CryptoKeySecurity(), null));
      rcsp.ImportCspBlob(tempRcsp.ExportCspBlob(true));
      dotnetCertificate2.PrivateKey = rcsp;
    // Save the certificate to the X509Store
