    [XmlRoot("type")]
    public class EventType
    {
        public EventType() { }
        [XmlElement("color")]
        public string Color { get; set; }
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
