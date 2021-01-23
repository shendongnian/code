        [XmlRoot("cachestore")]
        public class CacheStoreConfig
        {
            [XmlAttribute("type")]
            public String TypeName { get; set; }
            [XmlElement("cachegroups"]
            public CacheGroups cacheGroups { get; set; }
        }
        
        [XmlType("cachegroups")]
        public class CacheGroups
        {
            [XmlElement("cachegroups")]
            public List<CacheGroupConfig> CacheGroupConfig { get; set; }
            [XmlAttribute("group-selector-type")]
            public String group_selector_type { get; set; }
        }
        [XmlType("cachegroup")]
        public class CacheGroupConfig
        {
            [XmlAttribute("name")]
            public String Name { get; set; }
            [XmlAttribute("item-expiration")]
            public int ItemExpiration { get; set; }
            [XmlAttribute("max-size")]
            public string MaxSize { get; set; }
        }
