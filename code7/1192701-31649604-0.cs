    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlArray(ElementName = "stations"), XmlArrayItem(ElementName = "station")]
        public Station[] Stations { get; set; }
    }
    public class Station
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }
