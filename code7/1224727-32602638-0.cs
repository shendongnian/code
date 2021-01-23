    namespace Tool.Cons
    {
    class Result
    {
        [XmlElement("test-suite")]
        public testsuiteType[] testsuite { get; set; }
 
        /// <remarks/>
        [XmlAttribute()]
        public string name { get; set; }
 
        /// <remarks/>
        [XmlAttribute()]
        public decimal total { get; set; }
 
        /// <remarks/>
        [XmlAttribute()]
        public decimal failures { get; set; }
 
        /// <remarks/>
        [XmlAttribute("not-run")]
        public decimal notrun { get; set; }
 
        /// <remarks/>
        [XmlAttribute()]
        public string date { get; set; }
 
        /// <remarks/>
        [XmlAttribute()]
        public string time { get; set; }
    }
 
    class Program
    {
        static void AppendTestSuite(XDocument xdocument, testsuiteType suite)
        {
            var ser = new XmlSerializer(typeof(testsuiteType));
            using (var writer = xdocument.Root.CreateWriter())
            {
                // We need this for some reason...
                writer.WriteWhitespace("");
                ser.Serialize(writer, suite);
            }
        }
 
        static void Main(string[] args)
        {
            var res = GetTestResult();
            var xdoc = new XDocument();
            // Create the root element.
            using (var writer = xdoc.CreateWriter())           
                ser.Serialize(writer, res);
 
            // For testing purposes:
            AppendTestSuite(xdoc, res.testsuite);
            var _out = xdoc.ToString();
        }
    }
    }
