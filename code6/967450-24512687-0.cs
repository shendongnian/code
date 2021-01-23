        public static XmlDocument RemoveXmlns(XmlDocument doc)
        {
            XDocument d;
            using (var nodeReader = new XmlNodeReader(doc))
                d = XDocument.Load(nodeReader);
            d.Root.Descendants().Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
            foreach (var elem in d.Descendants())
                elem.Name = elem.Name.LocalName;
            var xmlDocument = new XmlDocument();
            using (var xmlReader = d.CreateReader())
                xmlDocument.Load(xmlReader);
            return xmlDocument;
        }
        public static XmlDocument RemoveXmlns(String xml)
        {
            XDocument d = XDocument.Parse(xml);
            d.Root.Descendants().Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
            foreach (var elem in d.Descendants())
                elem.Name = elem.Name.LocalName;
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(d.CreateReader());
            return xmlDocument;
        }
