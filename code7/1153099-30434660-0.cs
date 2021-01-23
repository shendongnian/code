    public class Record
    {
        [XmlElement("File")]
        public List<File> Files { get; set; }
    }
    
    public class File
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("Line")]
        public List<Line> Lines { get; set; } 
    }
    
    public class Line
    {
        [XmlAttribute("address")]
        public string Address { get; set; }
    
        [XmlAttribute("data")]
        public string Data { get; set; }
    }
