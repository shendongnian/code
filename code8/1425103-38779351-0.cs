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
                var results = doc.Descendants().Where(x => x.Name.LocalName == "Cube" && x.Attribute("currency") != null).Select(x => new {
                    currency = (string)x.Attribute("currency"),
                    rate = (double)x.Attribute("rate")
                }).ToList();
            }
        }
    }
