    [System.Xml.Serialization.XmlRootAttribute("locations", Namespace = "")]
    public class LocationList
    {
        [XmlElement("location", IsNullable = true)]
        public List<location> Locations { get; set; }
    }
