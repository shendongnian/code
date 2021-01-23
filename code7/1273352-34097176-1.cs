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
                var result = doc.Descendants("State").Where(x => x.Nodes().FirstOrDefault().ToString().Trim().Contains("Ohio")).Elements("City").Select(y => new {
                    City = y.Nodes().FirstOrDefault().ToString().Trim(),
                    Streets = y.Elements("Street").Select(z => new {
                        StreeName = z.Nodes().FirstOrDefault().ToString().Trim(),
                        Numbers = z.Elements("Number").Select(a => new {
                            Number = a.Value
                        }).ToList()
                    }).ToList()
                }).ToList();
            }
        }
    }
