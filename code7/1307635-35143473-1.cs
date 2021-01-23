    public class CacheGroups
    {
        [XmlAttribute("group-selector-type")]
        public string group_selector_type = "bubba";
        [XmlArray]
        public List<CacheGroupConfig> groups { get; set; }
    }
    public class CacheGroupConfig
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("item-expiration")]
        public int ItemExpiration { get; set; }
        [XmlAttribute("max-size")]
        public string MaxSize { get; set; }
        public CacheGroupConfig()
        {
            //empty
        }
        public CacheGroupConfig( string name, int itemExpiration, string maxSize)
        {
            Name = name;
            ItemExpiration = itemExpiration;
            MaxSize = maxSize;
        }
    }
    [XmlRoot("cachestore")]
    public class CacheStoreConfig
    {
        [XmlAttribute("type")]
        public string TypeName { get; set; }
        public CacheGroups CacheGroups { get; set; }
    }
