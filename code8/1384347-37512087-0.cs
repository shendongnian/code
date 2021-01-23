    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\Test.xml";
            static void Main(string[] args)
            {
                 XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("person").Select(x => new {
                    id = x.Attribute("id"),
                    count = x.Elements("votes").Count(),
                    sum = x.Elements("votes").Select(y => (int)y).Sum()
                }).ToList();
     
            }
        }
    }
