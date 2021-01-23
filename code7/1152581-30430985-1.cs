    [XmlRoot("result")]
    public class Result
    {
        [XmlElement("record")]
        public Record[] Records { get; set; }
    }
    public class Record
    {
        [XmlElement("field")]
        public Field[] Fields { get; set; }
    }
    public class Field
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
