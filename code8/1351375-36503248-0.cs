    [XmlRoot("ID")]
    public class ID
    {
        [XmlText, Key] // <-- here
        public int Id { get; set; }
        [XmlAttribute("default")]
        public string Default { get; set; }
    }
