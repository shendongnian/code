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
            const int NUMBER_OF_XML = 3;
            static void Main(string[] args)
            {
                string xml =
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                         "<RootDTO xmlns:json='http://james.newtonking.com/projects/json'>" +
                           "<destination>" +
                              "<name>xxx</name>" +
                           "</destination>" +
                           "<orderData>" +
                              "<items json:Array='true'>" +
                                    "<shipmentIndex Name=\"items\"></shipmentIndex>" +
                                    "<barcode>12345</barcode>" +
                              "</items>" +
                              "<misCode>9876543210</misCode>" +
                                  "<shipments>" +
                                        "<sourceShipmentId></sourceShipmentId>" +
                                        "<shipmentIndex Name=\"shipments\"></shipmentIndex>" +
                                  "</shipments>" +
                           "</orderData>" +
                          "</RootDTO>";
                XDocument doc = null;
                XDocument addedDocs = null;
                for (int count = 0; count < NUMBER_OF_XML; count++)
                {
                    if (count == 0)
                    {
                        doc = XDocument.Parse(xml);
                    }
                    else
                    {
                        addedDocs = XDocument.Parse(xml);
                        XElement orderData = doc.Descendants("orderData").FirstOrDefault();
                        XElement addedOrderData = doc.Descendants("orderData").FirstOrDefault();
                        List<XElement> children = addedOrderData.Elements().ToList();
                        foreach (XElement element in children)
                        {
                            orderData.Add(element);
                        }
                     }
                }
            }
        }
    }
