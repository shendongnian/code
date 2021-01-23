    public static X509Certificate GenerateRootCertificate(AsymmetricCipherKeyPair key, X509Name subjectAndIssuer, int serialNumber, int yearsValid)
        {
            X509V3CertificateGenerator gen = new X509V3CertificateGenerator();
            Asn1SignatureFactory sig = new Asn1SignatureFactory("SHA256withRSA", key.Private, new SecureRandom());
            DateTime notBefore = DateTime.Now;
            DateTime notAfter = DateTime.Now.AddYears(yearsValid);
    
            gen.SetSerialNumber(BigInteger.ValueOf(serialNumber));
            gen.SetSubjectDN(subjectAndIssuer);
            gen.SetIssuerDN(subjectAndIssuer);
            gen.SetPublicKey(key.Public);
    
            gen.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(true));
            gen.AddExtension(X509Extensions.KeyUsage, true, new KeyUsage(KeyUsage.DigitalSignature | KeyUsage.CrlSign | KeyUsage.KeyCertSign));
            gen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(key.Public));
            gen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(key.Public));
    
            gen.SetNotBefore(notBefore);
            gen.SetNotAfter(notAfter);
    
            return gen.Generate(sig);
        }
