    [Serializable]
    public class level
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
        [XmlArray("level")]
        public List<theItem> items { get; set; }
    }
