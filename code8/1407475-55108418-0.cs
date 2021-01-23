    [XmlRoot(Namespace = "myNamespace")]
    public class MyDocumentMetaData 
    {
        public string Title { get; set; }
        public List<string> CellRefrences { get; set; }
        public string ToXML()
        {
            var stringwriter = new System.IO.StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("myNamespace", "http://myNamespace.com");
            var serializer = new XmlSerializer(typeof(MyDocumentMetaData));
            serializer.Serialize(stringwriter, this, ns);
            var x = stringwriter.ToString();
            return x;
        }
        public static MyDocumentMetaData LoadFromXMLString(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(MyDocumentMetaData));
            return serializer.Deserialize(stringReader) as MyDocumentMetaData;
        }
    }
