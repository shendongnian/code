    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication82
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("book").Select(x => new
                {
                    id = (string)x.Attribute("id"),
                    author = (string)x.Element("author"),
                    genre = (string)x.Element("genre"),
                    price = (decimal)x.Element("price"),
                    date = (DateTime)x.Element("publish_date"),
                    description = (string)x.Element("description") 
                }).ToList();
            }
        }
    }
