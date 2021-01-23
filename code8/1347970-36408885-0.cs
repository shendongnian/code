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
                var results = doc.Descendants("Boards").Elements().Select(x => new
                {
                    name = x.Name.LocalName,
                    board = x,
                    ioControls = x.Descendants("IOControl").Select(y => new {
                        control = y,
                        value = y.Attribute("Value")
                    }).ToList()
                }).ToList();
            }
        }
    }
