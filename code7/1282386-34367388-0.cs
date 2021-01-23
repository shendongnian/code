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
                    "<NonFuel>" +
                        "<Desc>Non-Fuel</Desc>" +
                        "<Description>" +
                        "</Description>" +
                        "<Quantity/>" +
                        "<Amount/>" +
                        "<Additional/>" +
                        "<Dispute>0</Dispute>" +
                        "<Records>" +
                        "</Records>" +
                    "</NonFuel>";
                XDocument doc = XDocument.Parse(xml);
                string[] recordNames = {"A", "B", "C"};
                XElement records = doc.Descendants("Records").FirstOrDefault();
                foreach (string recordName in recordNames)
                {
                    XElement newRecord = new XElement(recordName + "Records",
                        new XElement(recordName + "InnerRecords",
                            new XElement(recordName + "SubInner", "SA78900")
                        )
                    );
                    records.Add(newRecord);
                }
            }
        }
    }
