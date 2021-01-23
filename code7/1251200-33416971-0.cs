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
                //<?xml version="1.0" encoding="utf-8"?>
                //<Document xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="urn:iso:std:iso:20022:tech:xsd:pain.001.001.03 pain.001.001.03.xsd">
                //  <GrpHdr>
                //    <Price Curency="EUR">
                //      40.55
                //    </Price>
                //  </GrpHdr>
                //</Document>
                string xml =
                   "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                   "<Document xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03 pain.001.001.03.xsd\">" +
                   "</Document>";
                XDocument doc = XDocument.Parse(xml);
                XElement document = (XElement)doc.FirstNode;
                XNamespace xsd = document.GetNamespaceOfPrefix("xsd");
                XNamespace xsi = document.GetNamespaceOfPrefix("xsi");
                document.Add(new XElement("GrpHddr",
                        new XElement("Price", new object[] {
                            new XAttribute("Currency", "EUR"),
                            40.55
                        })
                ));
            }
        }
    }
    ​
