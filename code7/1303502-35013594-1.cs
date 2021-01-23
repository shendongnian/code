    [Serializable, XmlRoot("urlset")]
        public class Urlset
        {
            [XmlElement("urlset") ]  //should be here
            public B5_Url[] urls;
        }
        [XmlType("url")]
        public class B5_Url
        {
            [XmlElement("loc")]
            public string loc;
            [XmlElement("lastmod")]
            public string lastmod;
            [XmlElement("changefreq")]
            public string changefreq;
        }
