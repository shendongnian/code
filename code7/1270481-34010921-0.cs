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
                 "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<level>" +
                    "<info w=\"1000\" h=\"500\"/>" +
                "</level>";
                XDocument doc = XDocument.Parse(xml);
                XElement level = (XElement)doc.FirstNode;
                level.Add("ground", new object[] {
                    new XElement("point", new XAttribute[] {
                        new XAttribute("val1", "val1"),
                        new XAttribute("val2", "val2")
                    })
                });
            }
        }
    }
    ​
