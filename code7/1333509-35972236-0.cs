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
                        "<imgdir name=\"02380000\">" +
                            "<imgdir name=\"info\">" +
                                "<canvas name=\"icon\" width=\"32\" height=\"32\">" +
                                    "<vector name=\"origin\" x=\"0\" y=\"32\"/>" +
                                "</canvas>" +
                                "<canvas name=\"iconRaw\" width=\"27\" height=\"38\">" +
                                    "<vector name=\"origin\" x=\"0\" y=\"38\"/>" +
                                "</canvas>" +
                                "<int name=\"price\" value=\"1\"/>" +
                                "<int name=\"tradeBlock\" value=\"1\"/>" +
                                "<int name=\"bigSize\" value=\"1\"/>" +
                                "<int name=\"only\" value=\"1\"/>" +
                                "<int name=\"monsterBook\" value=\"1\"/>" +
                                "<int name=\"mob\" value=\"100100\"/>" +
                            "</imgdir>" +
                            "<imgdir name=\"spec\">" +
                                "<int name=\"consumeOnPickup\" value=\"1\"/>" +
                            "</imgdir>" +
                        "</imgdir>";
                XDocument doc = XDocument.Parse(xml);
                foreach (XElement imgdir in doc.Elements("imgdir"))
                {
                    string MobID = (string)imgdir.Descendants("int").ToList().Where(x => (string)x.Attribute("name") == "mob").FirstOrDefault().Attribute("value");
                }
            }
        }
    }
