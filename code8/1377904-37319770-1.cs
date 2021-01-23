    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            const string XML_INPUT = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument inputDoc = XDocument.Load(XML_INPUT);
                List<XElement> hotelSearchResults = inputDoc.Descendants().Where(x => x.Name.LocalName == "HotelSearchResult").ToList();
                XNamespace aNS = hotelSearchResults[0].GetNamespaceOfPrefix("a");
                XNamespace bNS = hotelSearchResults[0].GetNamespaceOfPrefix("b");
                string header = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                   "<ArrayOfHotelSearchResult xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                   "</ArrayOfHotelSearchResult>";
                XDocument doc = XDocument.Parse(header);
                XElement arrayOfHotelSearchResult = (XElement)doc.FirstNode;
                int count = 0;
                foreach (XElement hotelSearchResult in hotelSearchResults)
                {
                    XElement newHotel = new XElement("HotelSearchResult");
                    arrayOfHotelSearchResult.Add(newHotel);
                    newHotel.Add(new object[] {
                        new XElement("ResultIndex", ++count),
                        new XElement("HotelCode", (string)hotelSearchResult.Descendants(bNS + "HotelCode").FirstOrDefault())
                    });
                    XElement price = new XElement("Price");
                    newHotel.Add(price);
                    price.Add(new XElement("CommissionType", (string)hotelSearchResult.Descendants(bNS + "CommissionType").FirstOrDefault())); 
                }
            }
        }
    }
