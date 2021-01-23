    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication77
    {
        class Program
        {
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml =
                "<Request>" +
                "</Request>";
                XDocument newDoc = XDocument.Parse(xml);
                XElement request = newDoc.Descendants("Request").FirstOrDefault();
                XDocument oldDoc = XDocument.Load(FILENAME);
                foreach (XElement dellAsset in oldDoc.Descendants("DellAsset"))
                {
                    XElement baseInfo = new XElement("BaseInfo");
                    request.Add(baseInfo);
                    baseInfo.Add(dellAsset.Element("MachineDescription"));
                    baseInfo.Add(dellAsset.Element("ParentServiceTag"));
                    baseInfo.Add(dellAsset.Element("ShipDate"));
                    XElement warranties = new XElement("Warranties");
                    baseInfo.Add(warranties);
                    XElement latestWarranty = dellAsset.Descendants("Warranty")
                        .OrderBy(x => (DateTime)x.Element("EndDate")).LastOrDefault();
                    
                    warranties.Add( new XElement("Warranty", new XElement[] {
                                  latestWarranty.Element("ServiceLevelDescription"),
                                  latestWarranty.Element("ServiceProvider"),
                                  latestWarranty.Element("StartDate"),
                                  latestWarranty.Element("EndDate"),
                                  latestWarranty.Element("EntitlementType")
                    }));
                            
                }
                
            }
        }
    }
