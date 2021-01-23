    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Framework.Models.News));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Framework.Models.News news = (Framework.Models.News)xs.Deserialize(reader);
            }
     
        }
    }
    namespace Framework.Models
    {
        [XmlRoot("News")]
        public class News
        {
            [XmlElement("Item")]
            public List<NewsModel> newsModel { get; set; } 
        }
        [XmlRoot("Item")]
        public class NewsModel
        {
            public NewsModel()
            {
                Title = string.Empty;
                Summary = string.Empty;
                Image = string.Empty;
                ImageWidth = 0;
                ImageHeight = 0;
                ImageSrcSet = string.Empty;
                ImageSizes = string.Empty;
                Url = "#";
                UrlText = string.Empty;
                UrlTarget = "_self";
                //Date = DateTime.Now;
            }
            [XmlElement("Title")]
            public String Title { get; set; }
            [XmlElement("Summary")]
            public String Summary { get; set; }
            [XmlElement("Image")]
            public String Image { get; set; }
            [XmlElement("ImageWidth")]
            public int ImageWidth { get; set; }
            [XmlElement("ImageHeight")]
            public int ImageHeight { get; set; }
            [XmlElement("ImageSrcSet")]
            public String ImageSrcSet { get; set; }
            [XmlElement("ImageSizes")]
            public String ImageSizes { get; set; }
            [XmlElement("Url")]
            public string Url { get; set; }
            [XmlElement("UrlText")]
            public String UrlText { get; set; }
            [XmlElement("UrlTarget")]
            public String UrlTarget { get; set; }
            [XmlElement("Date")]
            public string Date { get; set; }
        }
    }
