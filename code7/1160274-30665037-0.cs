    byte[] Sign (byte[] argBytesMsg)
    {
        var signedData = new CmsSignedDataStreamGenerator ();
        var x509certificate2 = LoadCertFromFile ("sign.p12");
        var cert = DotNetUtilities.FromX509Certificate (x509certificate2);
        var key = DotNetUtilities.GetKeyPair (x509certificate2.PrivateKey);
        signedData.AddSigner (key.PrivateKey, cert, X509ObjectIdentifiers.IdSha1.Id, null, null);
        signedData.AddCertificate (cert);
        using (var memory = new MemoryStream ()) {
            using (var stream = signedData.Open (memory, true))
                stream.Write (argBytesMsg, 0, argBytesMsg.Length);
            return memory.ToArray ();
        }
    }
