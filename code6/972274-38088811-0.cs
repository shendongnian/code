        // Verify the signature of an XML file and return the result.
        public static Boolean VerifySignRequest(String requestXML, string privateKeyIdentifier)
        {
            bool isValid = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                X509Store store = new X509Store(StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectKeyIdentifier, privateKeyIdentifier, false);
                X509Certificate2 cert = certs[0];
                // Create a new XML document.
                XmlDocument xmlDocument = new XmlDocument();
                // Format using white spaces.
                xmlDocument.PreserveWhitespace = true;
                // Load the passed XML file into the document. 
                xmlDocument.LoadXml(requestXML);
                // Create a new SignedXml object and pass it
                // the XML document class.
                SignedXml signedXml = new SignedXmlWithId(xmlDocument);
                // Find the "Signature" node and create a new
                // XmlNodeList object.
                XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
                // Load the signature node.
                signedXml.LoadXml((XmlElement)nodeList[0]);
                // Check the signature and return the result.
                isValid = signedXml.CheckSignature(cert,true);
            });
            return isValid;
        }
        /// <summary>
        /// SignedXmlWithId
        /// </summary>
        public class SignedXmlWithId : SignedXml
        {
            public SignedXmlWithId(XmlDocument xml)
                : base(xml)
            {
            }
            public SignedXmlWithId(XmlElement xmlElement)
                : base(xmlElement)
            {
            }
            public override XmlElement GetIdElement(XmlDocument doc, string id)
            {
                // check to see if it's a standard ID reference
                XmlElement idElem = base.GetIdElement(doc, id);
                if (idElem == null)
                {
                    XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                    nsManager.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                    idElem = doc.SelectSingleNode("//*[@wsu:Id=\"" + id + "\"]", nsManager) as XmlElement;
                }
                return idElem;
            }
        }
