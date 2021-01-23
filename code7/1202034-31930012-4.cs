    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
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
                var results = doc.Descendants("Locations").Elements().Select(x => x.Elements().Select(y => y.Elements().Select(z => new {
                    location = x.Name.ToString(),
                    floor = y.Name.ToString(),
                    section = z.Name.ToString(),
                    ip = z.Descendants("IP").Select(i => (string)i).ToList()
                })).SelectMany(a => a)).SelectMany(b => b).ToList();
            }
        }
    }
    ​
