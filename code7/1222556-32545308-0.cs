    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication47
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument xml = XDocument.Load("http://finance.yahoo.com/rss/headline?s=msft,goog,aapl");
                var rssData = (from item in xml.Descendants("channel")
                               select new RssModel
                               {
                                   Title = ((string)item.Element("title")),
                                   Link = ((string)item.Element("link")),
                                   Description = ((string)item.Element("description")),
                                   //Image = ((string)item.Element("enclosure").Attribute("url"))
                               }).Take(20).ToList();
            }
            public class RssModel
            {
                public string Title { get; set; }
                public string Link { get; set; }
                public string Description { get; set; }
                public string Image { get; set; }
            }
        }
    }
