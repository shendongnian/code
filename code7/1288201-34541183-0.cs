    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("ROWDETAIL").Select(x => new {
                    itemCode = x.Element("ITEMCODE").Value, 
                    description = x.Element("DSCRIPTION").Value,
                    quantity = (int)x.Element("QUANTITY"),
                    code = x.Element("WHSCODE").Value,
                    price = x.Element("UNITPRICE").Value,
                    group = x.Element("VATGROUP").Value,
                    discount = x.Element("PRICEAFTERDISCOUNT").Value,
                    batchFlag = x.Element("BATCHFLAG").Value,
                    batches = x.Elements("BATCH").Select(y => new {
                       number = y.Element("BATCHNUM").Value,
                       quantity = (int)y.Element("BATCHQTTY"),
                       expDate = DateTime.ParseExact(y.Element("EXPDATE").Value, "MM.dd.yy", CultureInfo.InvariantCulture)
                    }).ToList() 
                }).ToList();
     
            }
        }
       
    }
    ​
