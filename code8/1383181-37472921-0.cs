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
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"Windows-1252\"?>" +
                    "<Products>" +
                      "<Product>" +
                        "<ID>0701161476416</ID>" +
                        "<UNIQUE_ID>test26051603</UNIQUE_ID>" +
                        "<STATUS>DONE</STATUS>" +
                      "</Product>" +
                      "<Product>" +
                        "<ID>0701161476417</ID>" +
                        "<UNIQUE_ID>test26051604</UNIQUE_ID>" +
                        "<STATUS>DONE</STATUS>" +
                      "</Product>" +
                      "<Product>" +
                        "<ID>0701161476418</ID>" +
                        "<UNIQUE_ID>test26051605</UNIQUE_ID>" +
                        "<STATUS>DONE</STATUS>" +
                      "</Product>" +
                    "</Products>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("Product").Select(x => new
                {
                    id = (long)x.Element("ID"),
                    uniqueID = (string)x.Element("UNIQUE_ID"),
                    status = (string)x.Element("STATUS")
                }).ToList();
            }
        }
    }
