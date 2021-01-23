    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication38
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<Mapping xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                  "<Products>" +
                    "<Product>" +
                      "<software>Seiko</software>" +
                    "</Product>" +
                    "<Product>" +
                      "<hardware>Martina</hardware>" +
                    "</Product>" +
                  "</Products>" +
                "</Mapping>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("Product").Select(x => 
                    (x.Element("software") != null)? new {
                       type = "software",
                       value = (string)x.Element("software") } : 
                    (x.Element("hardware") != null)? new {
                        type = "hardware",
                        value = (string)x.Element("hardware") } : null
                ).ToList();
                var groups = results.GroupBy(x => x.type).ToList();
            }
        }
    }
