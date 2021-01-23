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
                string xml =
                    "<OrbiscomResponse IssuerId=\"5\" ReturnCode=\"Success\" Version=\"12.2\">" +
                        "<CreateApprovedPurchaseResponse PurchaseId=\"87654321\" Status=\"A\">" +
                            "<CPN AVV=\"123\" Expiry=\"1407\" Id=\"123456789\" PAN=\"5555444433332222\"/>" +
                        "</CreateApprovedPurchaseResponse>" +
                    "</OrbiscomResponse>";
                XElement response = XElement.Parse(xml);
                int purchaseId = int.Parse(response.Descendants("CreateApprovedPurchaseResponse").Attributes("PurchaseId").FirstOrDefault().Value);
                int avw = int.Parse(response.Descendants("CPN").FirstOrDefault().Attribute("AVV").Value); 
                int expiry = int.Parse(response.Descendants("CPN").Attributes("Expiry").FirstOrDefault().Value);
                string pan = response.Descendants("CPN").Attributes("PAN").FirstOrDefault().Value;
            }
        }
    }
    ​
