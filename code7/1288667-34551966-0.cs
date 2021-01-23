    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication63
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<Root>" +
                      "<div class=\"item\">" +
                        "<div class=\"name\">" +
                          "<b>Name of the item</b>" +
                        "</div>" +
                        "<div class=\"itemProp\">" +
                          "<input type=\"hidden\" name=\"index\" value=\"88\"/>" +
                        "</div>" +
                      "</div>" +
                      "<div class=\"item\">" +
                        "<div class=\"name\">" +
                          "<b>Name of the item</b>" +
                        "</div>" +
                        "<div class=\"itemProp\">" +
                          "<input type=\"hidden\" name=\"index\" value=\"88\"/>" +
                        "</div>" +
                      "</div>" +
                    "</Root>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants().Where(x => (x.Name.LocalName == "div") && (x.Attribute("class") != null) && x.Attribute("class").Value == "item").Select(y => new {
                    name = y.Descendants("b").FirstOrDefault().Value,
                    value = y.Descendants("input").FirstOrDefault().Attribute("value").Value
                }).ToList();
            }
        }
    }
