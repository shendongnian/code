    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication78
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string doc = string.Empty;
                StringBuilder builder = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(builder))
                {
                    XElement salesForecast =
                        new XElement(
                            "SalesForecast",
                            new XElement(
                                "header",
                                new XElement("EntryNumber", model.EntryNumber),
                                new XElement("EntryDate", model.EntryDate),
                                new XElement("Year", model.Year),
                                new XElement("Remarks", model.Remarks),
                                new XElement("RevisionID", model.RevisionID),
                                new XElement("Status", model.Status),
                                new XElement("CreatedBy", model.CreatedBy),
                                new XElement("CreatedDate", model.CreatedDate),
                                new XElement("LastModifiedBy", model.LastModifiedBy),
                                new XElement("LastModifiedDate", model.LastModifiedDate)),
                            new XElement(
                                "details",
                                model.Details.Select(detail =>
                                    new XElement(
                                        "SalesForecastDetails",
                                        new XElement("MonthID", detail.MonthID)))));
                    writer.WriteNode(salesForecast);
                    writer.WriteEndDocument(); //closes any open tags
                }
                
            }
        }
    }
