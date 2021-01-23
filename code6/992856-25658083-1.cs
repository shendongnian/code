    //RemoveNameSpaces
        public class NamespaceIgnorantXmlTextReader : XmlTextReader
        {
            public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader) : base(reader) { }
            public override string NamespaceURI
            {
                get { return ""; }
            }
        }
        //RemoveNameSpaces
        public class XTWFND : XmlTextWriter
        {
            public XTWFND(System.IO.TextWriter w) : base(w) { Formatting = System.Xml.Formatting.Indented; }
            public override void WriteStartDocument() { }
        }
        //Generate Generic XML Files
        public GenericXMLCLass GenericXmlGenerator()
        {
            var xDocument = XDocument.Load(@"myxml.xml"); 
            string xmlString = xDocumnet.ToString();
            GenericXMLCLass genericXML = new GenericXMLCLass();
            String xml;
                XmlDocument objDoc = new XmlDocument();
                objDoc.LoadXml(xmlString);
                XmlDocument objNewDoc = new XmlDocument();
                XmlElement objNewRoot = objNewDoc.CreateElement("GenericXMLClass");
                objNewDoc.AppendChild(objNewRoot);
                objNewRoot.InnerXml = objDoc.DocumentElement.InnerXml;
                xml = objNewDoc.OuterXml;
                
                    var serializer2 = new XmlSerializer(typeof(GenericXMLClass));
                    var reader = new StringReader(xml);
                    var instance = (GenericXMLClass)serializer2.Deserialize(new NamespaceIgnorantXmlTextReader(reader));
                    genericXML = instance;
                
            }
            return genericXML;
        }
