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
                    "<Root>" +
                        "<property name =\"Web Application\" value=\"\\Fxnet2\\Web\\webpl\" />" +
                        "<property name=\"Web Service\" value=\"\\FXnet2\\Web\\FXnet_SC_WS\" />" +
                    "</Root>";
                XElement root = XElement.Parse(input);
                var results = root.Descendants("property").Select(x => new {
                    name = x.Attribute("name").Value,
                    value = x.Attribute("value").Value
                }).ToList();
            }
        }
    }
    ​
