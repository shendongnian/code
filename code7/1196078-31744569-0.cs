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
                    "<Enums>" +
                        "<Enum name=\"Color\" guid=\"{2C68F947-3103-4F3C-9855-60F289B3A039}\">" +
                            "<Enumerator name=\"Red\" displayName=\"Red Color\"/>" +
                            "<Enumerator name=\"Green\" displayName=\"Green Color\" />" +
                            "<Enumerator name=\"Blue\" displayName=\"BlueColor\"/>" +
                        "</Enum>" +
                    "</Enums>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("Enum").Select(x => new {
                    name = x.Attribute("name").Value,
                    guid = x.Attribute("guid").Value,
                    enumerator = x.Elements("Enumerator").Select(y => new {
                        name = y.Attribute("name").Value,
                        displayName = y.Attribute("displayName").Value,
                        parent = x
                    }).ToList()
                }).ToList();
            }
        }
    }
    ​
