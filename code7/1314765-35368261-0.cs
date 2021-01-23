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
            static void Main(string[] args)
            {
                string xml =
                "<Request>" +
                    "<BaseInfo>" +
                        "<MachineName>a</MachineName>" +
                        "<ServiceTag>a12345</ServiceTag>" +
                        "<ShipDate>01/01/2000</ShipDate>" +
                            "<Warranties>" +
                                "<Warranty>" +
                                    "<ServiceLevelDescription>dfdlkfj</ServiceLevelDescription>" +
                                    "<ServiceProvider>ABC</ServiceProvider>" +
                                    "<StartDate>01/01/2001</StartDate>" +
                                    "<EndDate>01/05/2007</EndDate>" +
                                "</Warranty>" +
                                "<Warranty>" +
                                "</Warranty>" +
                            "</Warranties>" +
                    "</BaseInfo>" +
                    "<BaseInfo>" +
                        "<MachineName>b</MachineName>" +
                        "<ServiceTag>b12345</ServiceTag>" +
                        "<ShipDate>01/01/2010</ShipDate>" +
                            "<Warranties>" +
                                "<Warranty>" +
                                    "<ServiceLevelDescription>dfdlkfj</ServiceLevelDescription>" +
                                    "<ServiceProvider>ABCF</ServiceProvider>" +
                                    "<StartDate>01/01/2011</StartDate>" +
                                    "<EndDate>01/05/2017</EndDate>" +
                                "</Warranty>" +
                                "<Warranty>" +
                                "</Warranty>" +
                            "</Warranties>" +
                    "</BaseInfo>" +
                "</Request>";
                XDocument testing = XDocument.Parse(xml);
                var Baseinfo = (from baseInfo in testing.Descendants("BaseInfo")
                                select new
                                {
                                    MachineName = (string)baseInfo.Element("MachineDescription"),
                                    ServiceTag = (string)baseInfo.Element("ServiceTag"),
                                    WarrantyStart = (string)baseInfo.Element("ShipDate"),
                                    Warranties = (from warranty in baseInfo.Descendants("Warranty")
                                                  select new
                                                  {
                                                      Service = (string)warranty.Element("ServiceLevelDescription"),
                                                      Provider = (string)warranty.Element("ServiceProvider"),
                                                      StartDate = (string)warranty.Element("StartDate"),
                                                      EndDate = (string)warranty.Element("EndDate"),
                                                      TypeOfWarranty = (string)warranty.Element("EntitlementType")
                                                  }).ToList().GroupBy(x => x.Service)
                                }).AsEnumerable().ToList();
            }
        }
    }
