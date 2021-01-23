    [XmlRoot("records")]
    public class Records
    {
        [XmlArray("locations")]
        [XmlArrayItem("location")]
        public Location[] Locations { get; set; }
    }
    
    public class Location
    {
        [XmlAttribute("country")]
        public string Country { get; set; }
        [XmlAttribute("city")]
        public string City { get; set; }
        [XmlAttribute("state")]
        public string State { get; set; }
    }
