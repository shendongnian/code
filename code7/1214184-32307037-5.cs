            string xml;
            using (var sw = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true, IndentChars = "  " }))
                using (var xmlWriterProxy = new PrefixSelectingXmlWriterProxy(xmlWriter,
                    (string prefix, string localName, string ns, Stack<XName> parents) =>
                    {
                        if (localName == "StoreGeneratedPattern" && ns == annotation && parents.Peek() == XName.Get("Property", "http://schemas.microsoft.com/ado/2009/11/edm"))
                            return "annotation";
                        return prefix;
                    })
                    )
                {
                    csdlDoc.WriteTo(xmlWriterProxy);
                }
                xml = sw.ToString();
            }
            Debug.WriteLine(xml);
