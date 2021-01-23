    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                    "<Transmission>" +
                      "<TransmissionBody>" +
                        "<Release>" +
                          "<ShiptoLocation></ShiptoLocation>" +
                          "<TimeFrame></TimeFrame>" +
                        "</Release>" +
                      "</TransmissionBody>" +
                    "</Transmission>";
                XDocument doc = XDocument.Parse(xml);
                XElement releaseLine = new XElement("ReleaseLine",
                    new XElement("ReleaseLineGid",
                        new XElement("PackagedItemRef",
                            new XElement("ItemQuantity"))));
                XElement shipUnit =  new XElement("ShipUnit",
                    new XElement("ShipUnit",
                        new XElement("WeightVolume",
                            new XElement("ShipUnitContent"))));
                XElement release = doc.Descendants("Release").FirstOrDefault();
                release.Add(releaseLine);
                release.Add(shipUnit);
            }
        }
    }
