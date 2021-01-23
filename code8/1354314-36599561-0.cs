    [System.Xml.Serialization.XmlRootAttribute("claims", Namespace = "", IsNullable = false)]
    public class EPPDClaims
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("lang")]
        public string Lang { get; set; }
        [XmlElement("claim")]
        public List<EPPDClaim> Claims { get; set; }
    }
    public class EPPDClaim
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("num")]
        public int Number { get; set; }
        [XmlAnyElement("claim-text")]
        public XmlNode Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(EPPDClaims));
            var obj = (EPPDClaims)serializer.Deserialize(System.IO.File.OpenRead("test.xml"));
            string s = obj.Claims.First().Text.InnerXml;
        }
    }
