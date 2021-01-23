    public static void SignXml(XmlDocument xmlDoc, X509Certificate2 cert)
    {
            // transformation cert -> key omitted
            RSACryptoServiceProvider key;
            // Create a SignedXml object. 
            SignedXml signedXml = new SignedXml(xmlDoc);
            // Add the key to the SignedXml document. 
            signedXml.SigningKey = key;
            signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
            // Create a reference to be signed. 
            Reference reference = new Reference();
            reference.Uri = "#foo";
            reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
            // Add an enveloped transformation to the reference. 
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigExcC14NTransform());
            signedXml.AddReference(reference);
            KeyInfo keyInfo = new KeyInfo();
            KeyInfoX509Data keyInfoData = new KeyInfoX509Data();
            keyInfoData.AddIssuerSerial(cert.IssuerName.Format(false), cert.SerialNumber);
            keyInfo.AddClause(keyInfoData);
            signedXml.KeyInfo = keyInfo;
            // Compute the signature. 
            signedXml.ComputeSignature();
            // Add prefix "ds:" to signature
            XmlElement signature = signedXml.GetXml();
            SetPrefix("ds", signature);
            // Load modified signature back
            signedXml.LoadXml(signature);
            // this is workaround for overcoming a bug in the library
            signedXml.SignedInfo.References.Clear();
            // Recompute the signature
            signedXml.ComputeSignature();
            string recomputedSignature = Convert.ToBase64String(signedXml.SignatureValue);
            // Replace value of the signature with recomputed one
            ReplaceSignature(signature, recomputedSignature);
            // Append the signature to the XML document. 
            xmlDoc.DocumentElement.InsertAfter(xmlDoc.ImportNode(signature, true), xmlDoc.DocumentElement.FirstChild);
        }
        private static void SetPrefix(string prefix, XmlNode node)
        {
            node.Prefix = prefix;
            foreach (XmlNode n in node.ChildNodes)
            {
                SetPrefix(prefix, n);
            }
        }
        private static void ReplaceSignature(XmlElement signature, string newValue)
        {
            if (signature == null) throw new ArgumentNullException(nameof(signature));
            if (signature.OwnerDocument == null) throw new ArgumentException("No owner document", nameof(signature));
            XmlNamespaceManager nsm = new XmlNamespaceManager(signature.OwnerDocument.NameTable);
            nsm.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            XmlNode signatureValue = signature.SelectSingleNode("ds:SignatureValue", nsm);
            if (signatureValue == null)
                throw new Exception("Signature does not contain 'ds:SignatureValue'");
            signatureValue.InnerXml = newValue;
        }
