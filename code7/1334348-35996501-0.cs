    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication82
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<navdefinition>" +
                      "<link text=\"/and\" href=\"/and\">" +
                          "<link text=\"Overview\" href=\"/overview\"  />" +
                          "<link text=\"Information\" href=\"/fo\"/>" +
                      "</link>" +
                    "</navdefinition>";
                XDocument doc = XDocument.Parse(xml);
                XElement navDefinition = doc.Element("navdefinition");
                navDefinition.FirstNode.ReplaceWith(
                    new XElement("link", new object[] {
                        new XAttribute("text", "NewParent"),
                        new XAttribute("href", "/"),
                        new XElement("link", new object[] {
                            new XAttribute("text", "Sibling"),
                            new XAttribute("href", "/sibling"),
                            navDefinition.FirstNode
                        })
                    })
                );
     
            }
         
        }
    }
