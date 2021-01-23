    [Serializable, System.Xml.Serialization.XmlRoot("urlset")]
    public class Urlset
    {
        [System.Xml.Serialization.XmlElement("url")]
        public B5_Url[] urls;
    }
    [System.Xml.Serialization.XmlType("url")]
    public class B5_Url
    {
        [System.Xml.Serialization.XmlElement("loc")]
        public string loc;
        [System.Xml.Serialization.XmlElement("lastmod")]
        public string lastmod;
        [System.Xml.Serialization.XmlElement("changefreq")]
        public string changefreq;
    }
    class Program
    {
        static void Main(string[] args)
        {
    	    var data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><urlset><url><loc>http://www.myurl.de/</loc><lastmod>2012-06-25T17:10:30+00:00</lastmod><changefreq>always</changefreq></url></urlset>";
    
            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Urlset));
    
            Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
    
            Urlset reply = (Urlset)ser.Deserialize(stream);  
    		reply.Dump();
        }
    }
