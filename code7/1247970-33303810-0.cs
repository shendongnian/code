    public class XMLFile
    {
        public XMLFile()
        {
        }
        [XmlArray("channels")]
        [XmlArrayItem(Type = typeof(Ch01), ElementName = "Ch01")]
        [XmlArrayItem(Type = typeof(Ch02), ElementName = "Ch02")]
        public List<channel> channels = new List<channel>();
    }
