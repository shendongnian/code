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
                var results = doc.Descendants("Table").Select(x => new
                {
                    number = (int)x.Element("Number"),
                    name = (string)x.Element("Name"),
                    a = (double)x.Element("a"),
                    e = (double)x.Element("e"),
                    i = (double)x.Element("i"),
                    n = (double)x.Element("N"),
                    w = (double)x.Element("w"),
                    pyrs = (double)x.Element("Pyrs"),
                    mm = (double)x.Element("mm"),
                    ma0 = (double)x.Element("MA0")
                }).ToList();
            }
        }
    }
