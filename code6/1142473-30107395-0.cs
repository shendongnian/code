    [XmlRoot("xml")]  // Indicates that the root element is named "xml"
    public class XmlResponse
    {
        [XmlElement("result")] // Indicates that this element is named "result"
        public string Result { get; set; }
        [XmlArray("headers")]  // Indicates two-level list with outer element named "headers" and inner elements named "header"
        [XmlArrayItem("header")]
        public List<string> Headers { get; set; }
        [XmlArray("data")] // Indicates two-level list with outer element named "data" and inner elements named "datum"
        [XmlArrayItem("datum")]
        public List<XmlResponseDatum> Data { get; set; }
    }
    public class XmlResponseDatum
    {
        [XmlElement("item")] // Indicates a one-level list with repeated elements named "item".
        public List<string> Items { get; set; }
    }
