    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication78
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("physicalResource").Select(x => new {
                    prName = (string)x.Element("prName"),
                    characteristics = x.Descendants("characteristic").Select(y => new {
                           name = (string)y.Element("name"),
                           value = (string)y.Element("value")
                        }).ToList()
                    }).ToList();
            }
        }
    }
