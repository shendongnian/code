    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication37
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\"?>" +
                    "<accountlist>" +
                      "<main>" +
                        "<account id=\"1\" special_id=\"4923959\">" +
                          "<username>Adam</username>" +
                          "<motto>" +
                            "Hello Everyone>" +
                            "<money>1004</money>" +
                            "<friends>394</friends>" +
                            "<rareid>9</rareid>" +
                            "<mission>10</mission>" +
                          "</motto>" +
                          "</account>" +
                      "</main>" +
                    "</accountlist>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("accountlist").Select(x => new {
                    id = x.Element("main").Element("account").Attribute("id").Value,
                    special_id = x.Element("main").Element("account").Attribute("special_id").Value,
                    username = x.Element("main").Element("account").Element("username").Value,
                    motto = x.Element("main").Element("account").Element("motto").FirstNode.ToString(),
                    money = x.Element("main").Element("account").Element("motto").Element("money").Value,
                    friends = x.Element("main").Element("account").Element("motto").Element("friends").Value,
                    rareid = x.Element("main").Element("account").Element("motto").Element("rareid").Value,
                    mission = x.Element("main").Element("account").Element("motto").Element("mission").Value,
                }).ToList();
            }
        }
    }
