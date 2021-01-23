    [XmlRoot("eventtypes")]
    public class EventTypeList
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("eventtype")]
        public List<EventType> EventTypes { get; set; }
    }
    [XmlRoot("events")]
    public class EventList
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("event")]
        public List<Event> Events { get; set; }
    }
    [XmlRoot("event")]
    public class Event // Prototype implementation only, many properties omitted.
    {
        [XmlElement("title")]
        public string Title { get; set; }
        // Remainder omitted for brevity.
        [XmlElement("type")]
        public EventType Type { get; set; }
    }
