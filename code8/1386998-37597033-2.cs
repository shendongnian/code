    [XmlRoot(ElementName = "ItemDestination")]
    public class ItemDestination
    {
        [XmlAttribute(AttributeName = "DestinationType")]
        public string DestinationType { get; set; }
        [XmlAttribute(AttributeName = "Longitude")]
        public string Longitude { get; set; }
        [XmlAttribute(AttributeName = "Latitude")]
        public string Latitude { get; set; }
        [XmlAttribute(AttributeName = "RadiusKm")]
        public string RadiusKm { get; set; }
    }
