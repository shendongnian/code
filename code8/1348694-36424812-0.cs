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
                    "<stringList>" +
                        "<property1/>" +
                        "<property2/>" +
                           "<style>" +
                             "<queryString>" +
                             "</queryString>" +
                           "</style>" +
                        "<queryString>" +
                        "</queryString>" +
                    "</stringList>" +
                    "</root>";
                XDocument doc = XDocument.Parse(xml);
                var stringList = doc.Descendants("stringList").Select(x => new
                {
                    property1 = x.Element("property1"),
                    property2 = x.Element("property2"),
                    style = x.Element("style"),
                    queryString = x.Element("queryString")
                });
            }
        }
    }
