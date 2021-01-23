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
            const string FILENANE = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENANE);
                
                var customerQueryRs = doc.Descendants("CustomerQueryRs").Select(x => new {
                    statusCode = x.Attribute("statusCode").Value,
                    statusSeverity = x.Attribute("statusSeverity").Value,
                    statusMessage = x.Attribute("statusMessage").Value,
                    listID = x.Descendants("ListID").FirstOrDefault().Value,
                    addresses = x.Descendants("BillAddress").FirstOrDefault().Descendants().Select(y => new {
                        address = y.Value
                    }).ToList()
                }).ToList();
            }
        }
    }
    ​
