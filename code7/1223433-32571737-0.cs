    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("transaction").Select(x => new
                {
                    name = x.Attribute("name").Value,
                    request = x.Elements("request").Select(y => new {
                        transaction = y.Attribute("transaction").Value,
                        URLs = y.Element("URL").Value
                    }).ToList()
                }).ToList();
            }
        }
    }
    ​
