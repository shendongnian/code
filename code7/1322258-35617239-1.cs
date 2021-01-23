        public static bool Verify(XmlDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document), "XML document is null.");
            SignedXml signed = new SignedXml(document);
            XmlNodeList list = document.GetElementsByTagName("Signature");
            if (list == null)
                throw new CryptographicException($"The XML document has no signature.");
            if (list.Count > 1)
                throw new CryptographicException($"The XML document has more than one signature.");
            signed.LoadXml((XmlElement)list[0]);
            RSA rsa = null;
            foreach (KeyInfoClause clause in signed.KeyInfo)
            {
                RSAKeyValue value = clause as RSAKeyValue;
                if (value == null) continue;
                RSAKeyValue key = value;
                rsa = key.Key;
            }
            return rsa != null && signed.CheckSignature(rsa);
        }
