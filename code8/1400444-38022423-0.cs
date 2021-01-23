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
                    "<root>" +
                        "<element>" +
                            "<id>1</id>" +
                            "<group>first</group>" +
                        "</element>" +
                        "<element>" +
                            "<id>2</id>" +
                            "<group>second</group>" +
                        "</element>" +
                        "<element>" +
                            "<id>3</id>" +
                            "<group>first</group>" +
                        "</element>" +
                    "</root>";
                XDocument doc = XDocument.Parse(xml);
                var groups = doc.Descendants("element")
                    .GroupBy(x => (string)x.Element("group"))
                    .ToList();
                XElement newXml = new XElement("root");
                foreach(var group in groups)
                {
                    newXml.Add(new XElement("groups", new object[] {
                        new XAttribute("name", group.Key),
                            group
                    }));
                }
            
            }
        }
    }
