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
                List<Item> items = new List<Item>() {
                    new Item() { itemNumber = "PHAN-PHN-001", itemDescription = "Standard Phone Package", itemClass = "RETAIL"},
                    new Item() { itemNumber = "OM0325", itemDescription = "Dual Basic Headset", itemClass = "CATALOG"},
                    new Item() { itemNumber = "OM01373", itemDescription = "Light Cordless 1", itemClass = "CATALOG"}
                };
                string header = "<?xml version=\"1.0\" encoding= \"utf-8\" ?>" +
                    "<GreatPlainIntegration></GreatPlainIntegration>";
                XDocument doc = XDocument.Parse(header);
                XElement greatPlainsIntegration = (XElement)doc.FirstNode;
                greatPlainsIntegration.Add(new object[] {
                    new XElement("TransmissionDate", DateTime.Now.ToString("yyyy-M-d")),
                    new XElement("Batch", new object[] {
                        new XElement("BatchSource", "Inv Mstr"),
                        new XElement("DocumentElement")
                    })
                });
                XElement documentElement = greatPlainsIntegration.Descendants("DocumentElement").FirstOrDefault();
                documentElement.Add(items.Select(x => new XElement("Item", new XElement[] {
                    new XElement("ItemNumber", x.itemNumber),
                    new XElement("ItemDescription", x.itemDescription),
                    new XElement("ItemClass", x.itemClass)
                })).ToArray());
            }
        }
        public class Item
        {
            public string itemNumber { get; set; }
            public string itemDescription { get; set; }
            public string itemClass { get; set; }
        }
    }
