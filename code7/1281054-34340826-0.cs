    [XmlRoot("Envelope", Namespace = GesmesNameSpace)]
    public class EcbEnvelope
    {
        public const string GesmesNameSpace = "http://www.gesmes.org/xml/2002-08-01";
        public const string EcbNameSpace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";
        [XmlElement("Sender", Namespace = GesmesNameSpace)]
        public EcbSender Sender { get; set; }
        [XmlElement("subject", Namespace = GesmesNameSpace)]
        public string EcbSubject { get; set; }
        [XmlArray("Cube", Namespace = EcbNameSpace)]
        [XmlArrayItem("Cube")]
        public List<CubeRoot> CubeRootEl { get; set; }
        public class EcbSender
        {
            [XmlElement("name")]
            public string Name { get; set; }
        }
        public class CubeRoot
        {
            [XmlAttribute("time")]
            public string Time { get; set; }
            [XmlElement("Cube")]
            public List<CubeItem> CubeItems { get; set; }
            public class CubeItem
            {
                [XmlAttribute("rate")]
                public string RateStr { get; set; }
                [XmlIgnore]
                public decimal Rate
                {
                    get { return decimal.Parse(RateStr); }
                }
                [XmlAttribute("currency")]
                public string Currency { get; set; }
            }
        }
    }
