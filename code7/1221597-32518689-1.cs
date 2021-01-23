    using (DSACryptoServiceProvider csp = new DSACryptoServiceProvider(1024)) {
                var parameters = csp.ExportParameters(true);                
                var keypair = DotNetUtilities.GetDsaKeyPair(parameters);
                var gen = new X509V3CertificateGenerator();
                var CN = new X509Name("CN=" + "TEST");
                var SN = BigInteger.ProbablePrime(120, new Random());
                gen.SetSerialNumber(SN);
                gen.SetSubjectDN(CN);
                gen.SetIssuerDN(CN);
                gen.SetNotAfter(DateTime.Now.AddDays(1));
                gen.SetNotBefore(DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
                gen.SetSignatureAlgorithm("sha1WithDSA");
                gen.SetPublicKey(keypair.Public);
                var newCert = gen.Generate(keypair.Private);
                var certificateDSA = new X509Certificate2(DotNetUtilities.ToX509Certificate(newCert));
                // added block
                parameters.Seed = new byte[20];
                unchecked {
                    parameters.Counter = (int) 0xFFFFFFFF;
                }
                csp.ImportParameters(parameters);
                // end of added block
                certificateDSA.PrivateKey = csp;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("-----BEGIN CERTIFICATE-----");
                builder.AppendLine(Convert.ToBase64String(certificateDSA.Export(X509ContentType.Pkcs12), Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END CERTIFICATE-----");
                string result = builder.ToString();                
            }
