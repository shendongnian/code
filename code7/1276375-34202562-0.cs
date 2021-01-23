       public static XmlDocument TransformToHtml(XmlDocument XmlDoc, XmlDocument XSLT) {
            var bArr = new System.Text.UTF8Encoding().GetBytes(XmlDoc.InnerXml);
            MemoryStream m = new MemoryStream(bArr);
            System.Xml.XPath.XPathDocument xDoc;
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.CheckCharacters = false;
            using (XmlReader xr = XmlReader.Create(m, xrs)) {
                xDoc = new System.Xml.XPath.XPathDocument(xr);
            }
            StringBuilder resultString = new StringBuilder();
            var ws = new XmlWriterSettings();
            ws.CheckCharacters = false;
            ws.Indent = true;
            ws.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create(resultString, ws);
            var sets = new XsltSettings(true, true);
            string transformedXHTML = null;
            XslCompiledTransform transform = new XslCompiledTransform(false);
            transform.Load(XSLT, sets, null);
            transform.Transform(xDoc, writer);
            transformedXHTML = resultString.ToString();
            var doc = new XmlDocument();
            doc.LoadXml(transformedXHTML);
            return doc;
        }
