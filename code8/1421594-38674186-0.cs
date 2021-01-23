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
                var results = doc.Descendants("work").Select(x => new {
                    worktype = (string)x.Attribute("worktype"),
                    worktime = x.Elements("worktime").Select(y => new {
                        day = (int)y.Attribute("day"),
                        time = (DateTime)y.Attribute("time")
                    }).ToList()
                }).ToList();
            }
        }
    }
