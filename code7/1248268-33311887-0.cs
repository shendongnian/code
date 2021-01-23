    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication53
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                 "<groups>" +
                    "<group id=\"1\" name=\"group1\" location=\"null\">" +
                        "<member id=\"1\" name=\"Jack\" age=\"32\"/>" +
                        "<member id=\"2\" name=\"Tom\" age=\"25\"/>" +
                        "<member id=\"3\" name=\"John\" age=\"32\"/>" +
                    "</group>" +
                    "<group id=\"2\" name=\"group2\" location=\"null\">" +
                            "<member id=\"1\" name=\"Bob\" age=\"31\"/>" +
                            "<member id=\"2\" name=\"Michael\" age=\"34\"/>" +
                            "<member id=\"3\" name=\"Mike\" age=\"44\"/>" +
                    "</group>" +
                 "</groups>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("group").Select(x => new {
                    id = (int)x.Attribute("id"),
                    name = x.Attribute("name").Value,
                    location = x.Attribute("location").Value,
                    memebers = x.Elements("member").Select(y => new {
                        id = (int)y.Attribute("id"),
                        name = y.Attribute("name").Value,
                        age = (int)y.Attribute("age")
                    }).ToList()
                }).ToList();
            }
        }
    }
