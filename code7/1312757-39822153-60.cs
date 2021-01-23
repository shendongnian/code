        // http://stackoverflow.com/questions/36942094/how-can-i-generate-a-self-signed-cert-without-using-obsolete-bouncycastle-1-7-0
        public static System.Security.Cryptography.X509Certificates.X509Certificate2 CreateX509Cert2(string certName)
        {
            var keypairgen = new Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator();
            keypairgen.Init(new Org.BouncyCastle.Crypto.KeyGenerationParameters(
                new Org.BouncyCastle.Security.SecureRandom(
                    new Org.BouncyCastle.Crypto.Prng.CryptoApiRandomGenerator()
                    )
                    , 1024
                    )
            );
            Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair keypair = keypairgen.GenerateKeyPair();
            // --- Until here we generate a keypair
            var random = new Org.BouncyCastle.Security.SecureRandom(
                    new Org.BouncyCastle.Crypto.Prng.CryptoApiRandomGenerator()
            );
            // SHA1WITHRSA
            // SHA256WITHRSA
            // SHA384WITHRSA
            // SHA512WITHRSA
            // SHA1WITHECDSA
            // SHA224WITHECDSA
            // SHA256WITHECDSA
            // SHA384WITHECDSA
            // SHA512WITHECDSA
            Org.BouncyCastle.Crypto.ISignatureFactory signatureFactory = 
                new Org.BouncyCastle.Crypto.Operators.Asn1SignatureFactory("SHA512WITHRSA", keypair.Private, random)
            ;
            var gen = new Org.BouncyCastle.X509.X509V3CertificateGenerator();
            var CN = new Org.BouncyCastle.Asn1.X509.X509Name("CN=" + certName);
            var SN = Org.BouncyCastle.Math.BigInteger.ProbablePrime(120, new Random());
            gen.SetSerialNumber(SN);
            gen.SetSubjectDN(CN);
            gen.SetIssuerDN(CN);
            gen.SetNotAfter(DateTime.Now.AddYears(1));
            gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
            gen.SetPublicKey(keypair.Public);
            // -- Are these necessary ? 
            // public static readonly DerObjectIdentifier AuthorityKeyIdentifier = new DerObjectIdentifier("2.5.29.35");
            // OID value: 2.5.29.35
            // OID description: id-ce-authorityKeyIdentifier
            // This extension may be used either as a certificate or CRL extension. 
            // It identifies the public key to be used to verify the signature on this certificate or CRL.
            // It enables distinct keys used by the same CA to be distinguished (e.g., as key updating occurs).
            
            // http://stackoverflow.com/questions/14930381/generating-x509-certificate-using-bouncy-castle-java
            gen.AddExtension(
            Org.BouncyCastle.Asn1.X509.X509Extensions.AuthorityKeyIdentifier.Id,
            false,
            new Org.BouncyCastle.Asn1.X509.AuthorityKeyIdentifier(
                Org.BouncyCastle.X509.SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keypair.Public),
                new Org.BouncyCastle.Asn1.X509.GeneralNames(new Org.BouncyCastle.Asn1.X509.GeneralName(CN)),
                SN
            ));
            // OID value: 1.3.6.1.5.5.7.3.1
            // OID description: Indicates that a certificate can be used as an SSL server certificate.
            gen.AddExtension(
                Org.BouncyCastle.Asn1.X509.X509Extensions.ExtendedKeyUsage.Id,
                false,
                new Org.BouncyCastle.Asn1.X509.ExtendedKeyUsage(new ArrayList()
                {
                new Org.BouncyCastle.Asn1.DerObjectIdentifier("1.3.6.1.5.5.7.3.1")
            }));
            // -- End are these necessary ? 
            Org.BouncyCastle.X509.X509Certificate bouncyCert = gen.Generate(signatureFactory);
            byte[] ba = bouncyCert.GetEncoded();
            System.Security.Cryptography.X509Certificates.X509Certificate2 msCert = new System.Security.Cryptography.X509Certificates.X509Certificate2(ba);
            return msCert;
        }
