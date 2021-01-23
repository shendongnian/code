    [XmlRoot("urlset")] // or [XmlType("urlset")]
    public class UrlSet : List<Url>
    {
    }
    [XmlType("url")]
    public class Url
    {
        public string loc;
        public decimal priority;
        public string lastmod;
        public string changefreq;
    }
