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
                string input = 
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                        "<Users>" +
                          "<User Name=\"aa\" Occupation=\"dd\" Date_Of_Birth=\"123456\" NIC=\"123123\" ID=\"79461\" />" +
                          "<User Name=\"Ali Rasheed\" Occupation=\"Student\" Date_Of_Birth=\"111694\" NIC=\"4550246607037\" ID=\"12661\" />" +
                          "<User Name=\"Asif Rasheed\" Occupation=\"Civil Engineer\" Date_Of_Birth=\"241190\" NIC=\"4550346603073\" ID=\"90939\" />" +
                "</Users>";
                XDocument doc = XDocument.Parse(input);
                long searchID = 121661;
                long searchNic = 455024660703;
               
                var results = doc.Descendants ("User").Where(x => (long.Parse(x.Attribute("NIC").Value) == searchNic) || long.Parse(x.Attribute("ID").Value) == searchID)
                    .Select(y => new {id = long.Parse(y.Attribute("ID").Value), nic = long.Parse(y.Attribute("NIC").Value)}).ToList();
            }
        }
    }​
