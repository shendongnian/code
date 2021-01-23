    [XmlRoot("strokes", IsNullable = false)]
    public class Strokes
    {
        [XmlElement("stroke")]
        public List<Stroke> strokes;
    }
    public class Stroke
    {
        [XmlAttribute]
        public string timestamp;
        
        [XmlElement("coord")]
        public List<coord> coords;
    }
    [Serializable]
    public class coord
    {
        [XmlAttribute]
        public string x;
        [XmlAttribute]
        public string y;
        [XmlAttribute]
        public string d;
    }
