    [XmlRoot("urlset", Namespace="http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class Urlset
    {
        [XmlElement("url")]
        public B5_Url[] urlset;
    }
    public class B5_Url
    {
        [XmlElement("loc")]
        public string loc;
        [XmlElement("lastmod")]
        public string lastmod;
        [XmlElement("changefreq")]
        public string changefreq;
    }
