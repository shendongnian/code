    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var StoreInformation = doc.Descendants().Where(x => x.Name.LocalName == "StoreInformation").Select(y => new {
                    storeID = (string)y.Elements().Where(z => z.Name.LocalName == "StoreID").FirstOrDefault(),
                    businessDate = (DateTime)y.Elements().Where(z => z.Name.LocalName == "BusinessDate").FirstOrDefault(),
                    type = (string)y.Elements().Where(z => z.Name.LocalName == "Address").Select(a => a.Attribute("type")).FirstOrDefault(),
                    street = (string)y.Elements().Where(z => z.Name.LocalName == "Address").Select(a => a.Element(a.Name.Namespace + "Street")).FirstOrDefault(),
                    city = (string)y.Elements().Where(z => z.Name.LocalName == "Address").Select(a => a.Element(a.Name.Namespace + "City")).FirstOrDefault()
                }).ToList();
            }
        }
     }
