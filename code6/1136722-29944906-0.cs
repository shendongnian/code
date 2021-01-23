    public class DataTable
    {
        [XmlElement(ElementName = "schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Schema Schema { get; set; }
        [XmlElement(ElementName = "diffgram", Namespace="urn:schemas-microsoft-com:xml-diffgram-v1")]
        public Diffgram Diffgram { get; set; }
    }
    public class Schema
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element Element { get; set; }
    }
    
    public class Element
    {
        [XmlElement(ElementName = "complexType", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public ComplexType ComplexType { get; set; }
        [XmlAttribute(AttributeName = "name", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public String Name { get; set; }
    }
    public class ComplexType
    {
        [XmlElement(ElementName = "choice", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Choice Choice { get; set; }
        [XmlElement(ElementName = "sequence", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Sequence Sequence { get; set; }
    }
    public class Sequence
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element[] Elements { get; set; }
    }
    public class Choice
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element Element { get; set; }
    }
    public classDiffgram
    {
        [XmlElement(ElementName = "NewDataSet", Namespace = "")]
        public NewDataSet NewDataSet { get; set; }
    }
    public class NewDataSet
    {
        [XmlElement("geolocation")]
        public Geolocation[] Geolocations { get; set; }
    }
    public class Geolocation
    {
        [XmlElement("Latitude")]
        public double Latitude { get; set; }
        [XmlElement("Longitude")]
        public double Longitude { get; set; }
    }
