    var certificateStore = new CmsSignedData(new FileStream("chain.p7b", FileMode.Open));
    IX509Store x509Certs = certificateStore.GetCertificates("Collection");
    ArrayList a = new ArrayList(x509Certs.GetMatches(null));
    X509Certificate signerCert = (X509Certificate) a[0];
    var gen = new CmsSignedDataGenerator();
    gen.AddCertificates(x509Certs);
    gen.AddSigner(_privateKey, signerCert, CmsSignedGenerator.DigestSha1);
    CmsProcessable msg = new CmsProcessableByteArray(Encoding.ASCII.GetBytes(FullUnsignedMessage));
    CmsSignedData signedData = gen.Generate(msg, true);
