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
                string input = 
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<people type=\"array\">" +
                       "<person>" +
                          "<last-name>lastName</last-name>" +
                          "<first-name>firstName</first-name>" +
                          "<id type=\"integer\">123</id>" +
                          "<last-changed-on>2014-11-21T15:04:53Z</last-changed-on>" +
                       "</person>" +
                    "</people>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("person").Select(x => new {
                    last_name = x.Element("last-name").Value,
                    first_name = x.Element("first-name").Value,
                    id = int.Parse(x.Element("id").Value),
                    last_changed = DateTime.Parse(x.Element("last-changed-on").Value)
                }).ToList();
            }
        }
    }
    ​
