        static void Main()
        {
            //Console.WriteLine(ExecuteCommand("netsh http delete sslcert ipport=0.0.0.0:4443"));
            var applicationId = ((GuidAttribute)typeof(Program).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
            var certSubjectName = "TEST";
            var sslCert = ExecuteCommand("netsh http show sslcert 0.0.0.0:4443");
            Console.WriteLine();
            if (sslCert.IndexOf(applicationId, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("This implies we can start running.");
                Console.WriteLine(ExecuteCommand("netsh http delete sslcert ipport=0.0.0.0:4443"));
                //store.Remove(certs.First(x => x.Subject.Contains(certSubjectName)));
            }
            AsymmetricKeyParameter myCAprivateKey = null;
            Console.WriteLine("Creating CA");
            X509Certificate2 certificateAuthorityCertificate = CreateCertificateAuthorityCertificate("CN=" + certSubjectName + "CA", ref myCAprivateKey);
            Console.WriteLine("Adding CA to Store");
            AddCertificateToSpecifiedStore(certificateAuthorityCertificate, StoreName.Root, StoreLocation.LocalMachine);
            Console.WriteLine("Creating certificate based on CA");
            X509Certificate2 certificate = CreateSelfSignedCertificateBasedOnCertificateAuthorityPrivateKey("CN=" + certSubjectName, "CN=" + certSubjectName + "CA", myCAprivateKey);
            Console.WriteLine("Adding certificate to Store");
            AddCertificateToSpecifiedStore(certificate, StoreName.My, StoreLocation.LocalMachine);
            Console.WriteLine(ExecuteCommand($"netsh http add sslcert ipport=0.0.0.0:4443 certhash={certificate.Thumbprint} appid={{{applicationId}}}"));
            // Check to see if our cert exists
            // If the cert does not exist create it then bind it to the port
            // If the cert does exist then check the port it is bound to
            // If the port and thumbprint match and applicationId match continue
            // Else throw exception
            // See here for more netsh commands https://msdn.microsoft.com/en-us/library/ms733791(v=vs.110).aspx
        }
        public static X509Certificate2 CreateSelfSignedCertificateBasedOnCertificateAuthorityPrivateKey(string subjectName, string issuerName, AsymmetricKeyParameter issuerPrivKey)
        {
            const int keyStrength = 2048;
            // Generating Random Numbers
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom random = new SecureRandom(randomGenerator);
            ISignatureFactory signatureFactory = new Asn1SignatureFactory("SHA512WITHRSA", issuerPrivKey, random);
            // The Certificate Generator
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();
            certificateGenerator.AddExtension(X509Extensions.ExtendedKeyUsage, true, new ExtendedKeyUsage((new ArrayList() { new DerObjectIdentifier("1.3.6.1.5.5.7.3.1") })));
            // Serial Number
            BigInteger serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
            certificateGenerator.SetSerialNumber(serialNumber);
            // Signature Algorithm
            //const string signatureAlgorithm = "SHA512WITHRSA";
            //certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
            // Issuer and Subject Name
            X509Name subjectDN = new X509Name(subjectName);
            X509Name issuerDN = new X509Name(issuerName);
            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);
            // Valid For
            DateTime notBefore = DateTime.UtcNow.Date;
            DateTime notAfter = notBefore.AddYears(2);
            certificateGenerator.SetNotBefore(notBefore);
            certificateGenerator.SetNotAfter(notAfter);
            // Subject Public Key
            AsymmetricCipherKeyPair subjectKeyPair;
            var keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            subjectKeyPair = keyPairGenerator.GenerateKeyPair();
            certificateGenerator.SetPublicKey(subjectKeyPair.Public);
            // Generating the Certificate
            AsymmetricCipherKeyPair issuerKeyPair = subjectKeyPair;
            // selfsign certificate
            X509Certificate certificate = certificateGenerator.Generate(signatureFactory);
            // correcponding private key
            PrivateKeyInfo info = PrivateKeyInfoFactory.CreatePrivateKeyInfo(subjectKeyPair.Private);
            // merge into X509Certificate2
            X509Certificate2 x509 = new X509Certificate2(certificate.GetEncoded());
            Asn1Sequence seq = (Asn1Sequence)Asn1Object.FromByteArray(info.ParsePrivateKey().GetDerEncoded());
            if (seq.Count != 9)
            {
                //throw new PemException("malformed sequence in RSA private key");
            }
            RsaPrivateKeyStructure rsa = RsaPrivateKeyStructure.GetInstance(seq); //new RsaPrivateKeyStructure(seq);
            RsaPrivateCrtKeyParameters rsaparams = new RsaPrivateCrtKeyParameters(
                rsa.Modulus, rsa.PublicExponent, rsa.PrivateExponent, rsa.Prime1, rsa.Prime2, rsa.Exponent1, rsa.Exponent2, rsa.Coefficient);
            x509.PrivateKey = DotNetUtilities.ToRSA(rsaparams);
            return x509;
        }
        public static X509Certificate2 CreateCertificateAuthorityCertificate(string subjectName, ref AsymmetricKeyParameter CaPrivateKey)
        {
            const int keyStrength = 2048;
            // Generating Random Numbers
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom random = new SecureRandom(randomGenerator);
            // The Certificate Generator
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();
            // Serial Number
            BigInteger serialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
            certificateGenerator.SetSerialNumber(serialNumber);
            // Signature Algorithm
            //const string signatureAlgorithm = "SHA256WithRSA";
            //certificateGenerator.SetSignatureAlgorithm(signatureAlgorithm);
            // Issuer and Subject Name
            X509Name subjectDN = new X509Name(subjectName);
            X509Name issuerDN = subjectDN;
            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);
            // Valid For
            DateTime notBefore = DateTime.UtcNow.Date;
            DateTime notAfter = notBefore.AddYears(2);
            certificateGenerator.SetNotBefore(notBefore);
            certificateGenerator.SetNotAfter(notAfter);
            // Subject Public Key
            AsymmetricCipherKeyPair subjectKeyPair;
            KeyGenerationParameters keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
            RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            subjectKeyPair = keyPairGenerator.GenerateKeyPair();
            certificateGenerator.SetPublicKey(subjectKeyPair.Public);
            // Generating the Certificate
            AsymmetricCipherKeyPair issuerKeyPair = subjectKeyPair;
            ISignatureFactory signatureFactory = new Asn1SignatureFactory("SHA512WITHRSA", issuerKeyPair.Private, random);
            // selfsign certificate
            X509Certificate certificate = certificateGenerator.Generate(signatureFactory);
            X509Certificate2 x509 = new X509Certificate2(certificate.GetEncoded());
            CaPrivateKey = issuerKeyPair.Private;
            return x509;
            //return issuerKeyPair.Private;
        }
        public static bool AddCertificateToSpecifiedStore(X509Certificate2 cert, StoreName st, StoreLocation sl)
        {
            bool bRet = false;
            try
            {
                X509Store store = new X509Store(st, sl);
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
                store.Close();
            }
            catch
            {
                Console.WriteLine("An error occured");
            }
            return bRet;
        }
        public static string ExecuteCommand(string action)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    Arguments = "/c " + action
                }
            })
            {
                Console.WriteLine("Executing Command:");
                Console.WriteLine(action);
                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    stringBuilder.AppendLine(process.StandardOutput.ReadLine());
                }
                process.Close();
            }
            return stringBuilder.ToString();
        }
