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
                var result = doc.Descendants("Book")
                    .Select(b => new
                    {
                        ISBN = b.Attribute("ISBN").Value,
                        Genre = b.Attribute("Genre").Value,
                        Side = b.Element("Title").Attribute("Side").Value,
                        ptr = b.Element("Title").Elements("Pty").Select(x => new {
                            R = x.Attribute("R").Value,
                            PtyID = x.Attribute("ID").Value,
                            Typ = x.Elements("Sub").Select(y => y == null ? null : y.Attribute("Typ").Value).FirstOrDefault(),
                            SubIDTyp = x.Elements("Sub").Select(y => y == null ? null : y.Attribute("ID").Value).FirstOrDefault()
                        }).ToList()
                    })
                    .ToList();
            }
        }
    }
    ​
