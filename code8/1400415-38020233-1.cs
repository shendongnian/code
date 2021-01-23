    [System.Xml.Serialization.XmlRootAttribute("locations", Namespace = "")]
    public class LocationList
    {
        [XmlElement("location", IsNullable = false)]
        public List<location> Locations { get; set; }
    }
