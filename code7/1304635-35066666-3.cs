    using System.Xml.Serialization;
    [XmlRoot]
    public class Applications
    {
        [XmlElement]
        public string[] AccessibleApplication;
        [XmlElement]
        public string[] EligibleApplication;
    }
