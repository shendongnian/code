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
                    "<xml number=\"1\" Maintain=\"Yes\">" +
                        "<define count=\"0\"/>" +
                        "<Root Details=\"false\">" +
                          "<Project count=\"45\" Name=\"Success\">" +
                                "<Maintainance Id=\"123\" Title=\"Good\">" +
                                    "<Maintain Id=\"ABC\" />" +
                                    "<Maintain Id=\"DEF\" />" +
                                    "<Maintain Id=\"GHI\" />" +
                                "</Maintainance>" +
                                "<Maintainance Id=\"456\" Title=\"Better\">" +
                                    "<Maintain Id=\"JKL\" />" +
                                    "<Maintain Id=\"MNO\" />" +
                                    "<Maintain Id=\"PQR\" />" +
                                "</Maintainance>" +
                                "<Maintainance Id=\"789\" Title=\"Bad\">" +
                                    "<Maintain Id=\"STU\" />" +
                                    "<Maintain Id=\"VWX\" />" +
                                    "<Maintain Id=\"XYZ\" />" +
                                "</Maintainance>" +
                          "</Project>" +
                        "</Root>" +
                       "</xml>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> maintainances = doc.Descendants("Maintainance").ToList();
                foreach (XElement maintainance in maintainances)
                {
                    string[] ids = maintainance.Elements("Maintain").Select(x => x.Attribute("Id").Value).ToArray();
                    maintainance.ReplaceWith(new XElement("Maintainance", new object[] {
                        maintainance.Attribute("Id"),
                        new XAttribute("Fields", string.Join(",", ids))
                    }));
                }
            }
        }
    }
