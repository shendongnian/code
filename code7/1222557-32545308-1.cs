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
                var results = xml.Descendants("channel").Select(x => new
                {
                    Title = ((string)x.Element("title")),
                    Link = ((string)x.Element("link")),
                    Description = ((string)x.Element("description")),
                    Image = ((string)x.Element("image").Element("url")),
                    items = x.Elements("item").Take(20).Select(y => new {
                        title = (string)y.Element("title"),
                        link = (string)y.Element("link"),
                        description = (string)y.Element("description")
                    }).ToList(),
                }).FirstOrDefault();
            }
           
        }
    }
