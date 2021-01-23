    [Serializable, XmlRoot("urlset")]
    public class Urlset
    {
        [XmlElement("url")]
		public B5_Url[] urls;
    }
