    [Serializable]
    [XmlRoot("response")]
    public class IdentifyData
    {
        [XmlElement("modules")]
        public Modules modules { get; set; }
    }
    
    [Serializable]
    public class Modules
    {
        [XmlElement]
        public Channel channel { get; set; }
        [XmlElement]
        public Image image { get; set; }
    }
    [Serializable]
    public class Image
    {
        [XmlArray("resources")]
        [XmlArrayItem("resource")]
        public List<Resources> resources { get; set; }
    
    }
    
    [Serializable]
    public class Channel
    {
        [XmlArray("resources")]
        [XmlArrayItem("resource")]
        public List<Resources> resources { get; set; }
    }
    
    [Serializable]
    public class Resources
    {
        [XmlAttribute]
        public string name { get; set; }
    
        [XmlAttribute]
        public string url { get; set; }
    
        [XmlAttribute]
        public string refresh_interval { get; set; }
    
        [XmlText]
        public string someText { get; set; }
    }
