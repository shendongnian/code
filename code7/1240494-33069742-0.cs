    [Serializable, XmlRoot("root"), XmlType("root")]
    public class root
    {        
        [XmlArray("posts")]
        [XmlArrayItem("post")]
        public List<post> postList = new List<post>();
        [XmlArray("comments")]
        [XmlArrayItem("comment")]
        public List<comment> comments = new List<comment>();
    }
