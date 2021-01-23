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
                    "<data name=\"Rows\">" +
                       "<data Name=\"Row\">" +
                         "<data name=\"CONTACT\">John Smith</data>" +
                         "<data name=\"PHONE1\">(555)123-4567</data>" +
                       "</data>" +
                       "<data Name=\"Row\">" +
                         "<data name=\"CONTACT\">Jim Smith</data>" +
                         "<data name=\"PHONE1\">(555)123-6754</data>" +
                       "</data>" +
                    "</data>";
                XElement doc = XElement.Parse(xml);
                var results = doc.Descendants().Where(x => (string)x.Attribute("Name") == "Row").Select(x => new {
                   contact = x.Elements().Where(y => (string)y.Attribute("name") == "CONTACT").FirstOrDefault().Value,
                   phone = x.Elements().Where(y => (string)y.Attribute("name") == "PHONE1").FirstOrDefault().Value,
                }).ToList();
            }
        }
    }
    ​
