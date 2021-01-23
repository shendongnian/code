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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants().Where(x => x.Name.LocalName == "TrxDetailCard").Select(y => new {
                   TRX_HD_Key = (int)y.Element(y.Name.Namespace + "TRX_HD_Key"),
                   Invoice_ID = (int)y.Element(y.Name.Namespace + "Invoice_ID"),
                   Date_DT = (DateTime)y.Element(y.Name.Namespace + "Date_DT"),
                   Merchant_Key = (int)y.Element(y.Name.Namespace + "Merchant_Key")
                }).ToList();
            }
        }
     
    }
