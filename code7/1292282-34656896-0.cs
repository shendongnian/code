    [System.Serializable]
    public class channel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string language { get; set; }
        public string webMaster { get; set; }
        public string lastBuildDate { get; set; }
    
        [XmlElement("item")]
        public List<item> listItem
        {
            get;
            set;
        }
    }
    [Serializable]
    public class item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string pubDate { get; set; }
        public string Link { get; set; }
    }
