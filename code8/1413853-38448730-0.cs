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
                List<XElement> loans = doc.Descendants("LOANS").ToList();
                foreach (XElement loan in loans)
                {
                    string sellerLoanIdentifier = (string)loan.Descendants("SellerLoanIdentifier").FirstOrDefault();
                    XElement buydownInformation = loan.Descendants("BuydownInformation").FirstOrDefault();
                    buydownInformation.Value = sellerLoanIdentifier;
                }
            }
        }
    }
