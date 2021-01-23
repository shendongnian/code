        private static int Sign(Options options)
        {
            XmlDocument document = new XmlDocument {PreserveWhitespace = false};
            try
            {
                document.Load(options.File);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid XML file: {0}.", ex.Message);
                return -3;
            }
            XmlElement signature;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
                if (!string.IsNullOrEmpty(options.Key) && File.Exists(options.Key))
                {
                    using (StreamReader reader = new StreamReader(options.Key))
                        rsa.FromXmlString(reader.ReadToEnd());
                }
                else
                {
                    FileInfo fi = new FileInfo(options.File);
                    if (fi.DirectoryName == null) return -7;
                    string keyFile = Path.Combine(fi.DirectoryName, "signature.key");
                    using (StreamWriter writer = new StreamWriter(keyFile))
                        writer.Write(rsa.ToXmlString(true));
                }
                
                SignedXml signedXml = new SignedXml(document) {SigningKey = rsa};
                KeyInfo info = new KeyInfo();
                info.AddClause(new RSAKeyValue(rsa));
                signedXml.KeyInfo = info;
                Reference reference = new Reference {Uri = ""};
                reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                reference.AddTransform(new XmlDsigC14NTransform());
                signedXml.AddReference(reference);
                signedXml.ComputeSignature();
                signature = signedXml.GetXml();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error signing XML file: {0}.", ex.Message);
                return -4;
            }
            try
            {
                if (document.DocumentElement == null)
                {
                    Console.WriteLine("Document has no document element.");
                    return -6;
                }
                document.DocumentElement.AppendChild(document.ImportNode(signature, true));
                document.Save(options.File);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving signed XML file: {0}.", ex.Message);
                return -5;
            }
            return 0;
        }
