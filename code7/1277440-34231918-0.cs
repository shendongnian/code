    using System.Xml.Serialization;
    ...
    [XmlRoot("root")]
    public class Example {
        [XmlArray("data")]
        [XmlArrayItem("entry")]
        public List<Entry> Entries { get; set; }
    }
    public class Entry {
        [XmlAttribute("Attrib1")]
        public string Attrib1 { get; set; }
        [XmlAttribute("Attrib2")]
        public string Attrib2 { get; set; }
        [XmlAttribute("Attrib3")]
        public string Attrib3 { get; set; }
        [XmlAttribute("Attrib4")]
        public string Attrib4 { get; set; }
    }
    var xml = new XmlSerializer(typeof(Example), "");
    xml.Serialize(stream, example);
