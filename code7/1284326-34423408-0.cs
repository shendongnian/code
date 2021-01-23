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
                    "<Orders>" +
                      "<Order>" +
                        "<Number>1</Number>" +
                        "<GenerateID>Y</GenerateID>" +
                        "<DeliveryMethods>" +
                        "<DeliveryMethod>Postal</DeliveryMethod>" +
                        "<DeliveryMethod>Mail</DeliveryMethod>" +
                        "</DeliveryMethods>" +
                        "<OrderIdentity>1FTHX26FXVEA28985</OrderIdentity>" +
                        "<Price>100</Price>" +
                        "<Quantity>5</Quantity>" +
                      "</Order>" +
                    "</Orders>";
                XDocument doc = XDocument.Parse(xml);
                XElement deliverMethod = new XElement("DeliveryMethod",string.Join(",",doc.Descendants("DeliveryMethod").Select(x => x.Value).ToArray()));
            }
        }
    }
    ​
