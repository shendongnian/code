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
                    "<Document>" +
                      "<DefaultContainer>" +
                        "<Mobile_Devices>" +
                          "<Mobile_Device>" +
                            "<Id>1</Id>" +
                            "<Name>Device-One</Name>" +
                          "</Mobile_Device>" +
                        "</Mobile_Devices>" +
                      "</DefaultContainer>" +
                      "<ExlusionContainer>" +
                        "<Mobile_Devices>" +
                          "<Mobile_Device>" +
                            "<Id>2</Id>" +
                            "<Name>Device-Two</Name>" +
                          "</Mobile_Device>" +
                        "</Mobile_Devices>" +
                        "<Laptops />" +
                      "</ExlusionContainer>" +
                    "</Document>";
                string newNode = 
                    "<Mobile_Device>" +
                        "<Id>3</Id>" +
                        "<Name>Device-Three</Name>" +
                       "</Mobile_Device>";
                XDocument doc = XDocument.Parse(input);
                XElement newElement = XElement.Parse(newNode);
                XElement exlusionContainer = doc.Descendants("ExlusionContainer").FirstOrDefault();
                XElement mobileDevice = exlusionContainer.Element("Mobile_Devices").Element("Mobile_Device");
                mobileDevice.ReplaceWith(new XElement[] { mobileDevice, newElement });
            }
        }
    }
    ​
