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
                    "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>" +
                    "<root>" +
                        "<key name=\"some text\" id=\"1\"/>" +
                        "<key name=\"some text\" id=\"2\"/>" +
                        "<house id=\"H1\">" +
                            "<floor id=\"F1\">" +
                                "<room id=\"R1\">Child1<electrics><socket id=\"C1S1\"/></electrics></room>" +
                                "<room id=\"R2\">Child2<electrics><socket id=\"C2S1\"/></electrics></room>" +
                            "</floor>" +
                        "</house>" +
                    "</root>";
                
                XElement xmlDoc = XElement.Parse(input);
                XElement floor = xmlDoc.Descendants("floor").FirstOrDefault();
                XElement newR1 = new XElement(floor.Elements("room").Where(x => x.Attribute("id").Value == "R1").FirstOrDefault());
                XAttribute socket = newR1.Element("electrics").Element("socket").Attribute("id");
                socket.Value = "new room";
                floor.Add(newR1);
            }
        }
    }
    ​
