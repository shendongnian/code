    public static class XmlSigning
    {
        private static Type tSignedXml = typeof(SignedXml);
        private static ResourceManager SecurityResources = new ResourceManager("system.security", tSignedXml.Assembly);
        //these methods from the SignedXml class still work with prefixed Signature elements, but they are private
        private static ParameterExpression thisSignedXmlParam = Expression.Parameter(tSignedXml);
        private static Func<SignedXml, bool> CheckSignatureFormat
            = Expression.Lambda<Func<SignedXml, bool>>(
                Expression.Call(thisSignedXmlParam, tSignedXml.GetMethod("CheckSignatureFormat", BindingFlags.NonPublic | BindingFlags.Instance)),
                thisSignedXmlParam).Compile();
        private static Func<SignedXml, bool> CheckDigestedReferences
            = Expression.Lambda<Func<SignedXml, bool>>(
                Expression.Call(thisSignedXmlParam, tSignedXml.GetMethod("CheckDigestedReferences", BindingFlags.NonPublic | BindingFlags.Instance)),
                thisSignedXmlParam).Compile();
        public static void SignEnveloped(XmlDocument xmlDoc, RSACryptoServiceProvider key, string signatureNamespacePrefix)
        {
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = key;
            Reference reference = new Reference("");
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();
            XmlElement xmlSignature = signedXml.GetXml();
            if (!string.IsNullOrEmpty(signatureNamespacePrefix))
            {
                //Here we set the namespace prefix on the signature element and all child elements to "ds", invalidating the signature.
                AssignNameSpacePrefixToElementTree(xmlSignature, "ds");
                //So let's recompute the SignatureValue based on our new SignatureInfo...
                //For XPath
                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
                namespaceManager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#"); //this prefix is arbitrary and used only for XPath
                XmlElement xmlSignedInfo = xmlSignature.SelectSingleNode("ds:SignedInfo", namespaceManager) as XmlElement;
                //Canonicalize the SignedInfo element
                XmlDsigC14NTransform transform = new XmlDsigC14NTransform();
                XmlDocument signedInfoDoc = new XmlDocument();
                signedInfoDoc.LoadXml(xmlSignedInfo.OuterXml);
                transform.LoadInput(signedInfoDoc);
                //Compute the new SignatureValue
                string signatureValue = Convert.ToBase64String(key.SignData(transform.GetOutput() as MemoryStream, new SHA1CryptoServiceProvider()));
                //Set it in the xml
                XmlElement xmlSignatureValue = xmlSignature.SelectSingleNode("ds:SignatureValue", namespaceManager) as XmlElement;
                xmlSignatureValue.InnerText = signatureValue;
            }
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlSignature, true));
        }
        public static bool CheckSignature(XmlDocument xmlDoc, RSACryptoServiceProvider key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            SignedXml signedXml = new SignedXml(xmlDoc);
            //For XPath
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#"); //this prefix is arbitrary and used only for XPath
            XmlElement xmlSignature = xmlDoc.SelectSingleNode("//ds:Signature", namespaceManager) as XmlElement;
            signedXml.LoadXml(xmlSignature);
            //These are the three methods called in SignedXml's CheckSignature method, but the built-in CheckSignedInfo will not validate prefixed Signature elements
            return CheckSignatureFormat(signedXml) && CheckDigestedReferences(signedXml) && CheckSignedInfo(signedXml, key);
        }
        private static bool CheckSignedInfo(SignedXml signedXml, AsymmetricAlgorithm key)
        {
            //Copied from reflected System.Security.Cryptography.Xml.SignedXml
            SignatureDescription signatureDescription = CryptoConfig.CreateFromName(signedXml.SignatureMethod) as SignatureDescription;
            if (signatureDescription == null)
                throw new CryptographicException(SecurityResources.GetString("Cryptography_Xml_SignatureDescriptionNotCreated"));
            Type type = Type.GetType(signatureDescription.KeyAlgorithm);
            Type type2 = key.GetType();
            if (type != type2 && !type.IsSubclassOf(type2) && !type2.IsSubclassOf(type))
                return false;
            HashAlgorithm hashAlgorithm = signatureDescription.CreateDigest();
            if (hashAlgorithm == null)
                throw new CryptographicException(SecurityResources.GetString("Cryptography_Xml_CreateHashAlgorithmFailed"));
            //Except this. The SignedXml class creates and cananicalizes a Signature element without any prefix, rather than using the element from the document provided
            byte[] c14NDigest = GetC14NDigest(signedXml, hashAlgorithm);
            AsymmetricSignatureDeformatter asymmetricSignatureDeformatter = signatureDescription.CreateDeformatter(key);
            return asymmetricSignatureDeformatter.VerifySignature(c14NDigest, signedXml.Signature.SignatureValue);
        }
        private static byte[] GetC14NDigest(SignedXml signedXml, HashAlgorithm hashAlgorithm)
        {
            Transform canonicalizeTransform = signedXml.SignedInfo.CanonicalizationMethodObject;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(signedXml.SignedInfo.GetXml().OuterXml);
            canonicalizeTransform.LoadInput(xmlDoc);
            return canonicalizeTransform.GetDigestedOutput(hashAlgorithm);
        }
        private static void AssignNameSpacePrefixToElementTree(XmlElement element, string prefix)
        {
            element.Prefix = prefix;
            foreach (var child in element.ChildNodes)
            {
                if (child is XmlElement)
                    AssignNameSpacePrefixToElementTree(child as XmlElement, prefix);
            }
        }
    }
