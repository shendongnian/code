    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(RssFeedModel));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                RssFeedModel rssFeedModel = (RssFeedModel)xs.Deserialize(reader);
            }
        }
    }
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class RssFeedModel
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("link")]
        public List<Link> link { get; set; }
        [XmlElement("entry")]
        public List<Entry> entry { get; set; }
    }
    [XmlRoot("link")]
    public class Link
    {
        [XmlAttribute("rel")]
        public string rel { get; set; }
        [XmlAttribute("type")]
        public string type { get; set; }
    }
    [XmlRoot("entry")]
    public class Entry
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("published")]
        public DateTime PublishDate { get; set; }
        [XmlElement("content")]
        public Content content { get; set; }
    }
    [XmlRoot("content")]
    public class Content
    {
        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlText]
        public string text { get; set; }
    }
    ​
