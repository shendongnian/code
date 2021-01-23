           XmlNamespaceManager ns = new XmlNamespaceManager(SAMLXML.NameTable);
            ns.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            XmlElement xeAssertion = SAMLXML.DocumentElement.SelectSingleNode("saml:Assertion", ns) as XmlElement;
            string xml = null;
            var memoryStream = new MemoryStream();
            var serializer = new XmlSerializer(xeAssertion.GetType());
            var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
            serializer.Serialize(streamWriter, xeAssertion);
            memoryStream = (MemoryStream)streamWriter.BaseStream;
           
            xml = memoryStream.ToArray().Utf8ByteArrayToString();
            var serializer = new XmlSerializer(typeof(AssertionType));
            var memoryStream = new MemoryStream(xml.StringToUtf8ByteArray());
           
             AssertionType assertion = (AssertionType)serializer.Deserialize(memoryStream);
             return assertion;
