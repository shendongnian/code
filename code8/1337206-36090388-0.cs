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
                    "<Root Details=\"false\">" +
                      "<Product count=\"45\" Name=\"Success\">" +
                          "<Project Id=\"420\" Title=\"First\"/>" +
                          "<Main Id=\"220\" Title=\"Last\"/>" +
                          "<Status>" +
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
                           "</Status>" +
                          "<Main Id=\"420\" Title=\"Failure\"/>" +
                          "<Project Id=\"220\" Title=\"First\"/>" +
                      "</Product>" +
                    "</Root>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> maintainances = doc.Descendants("Maintainance").ToList();
                XElement product = doc.Descendants("Product").FirstOrDefault();
                product.ReplaceWith(new XElement("Product", product.Attributes()));
                product = doc.Descendants("Product").FirstOrDefault();
                foreach (XElement maintainance in maintainances)
                {
                    product.Add(maintainance);
                }
            }
        }
    }
