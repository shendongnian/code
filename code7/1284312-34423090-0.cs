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
            const string FILENMAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENMAME);
                var brand = doc.Descendants("brand").Select(x => new
                {
                    name = x.Attribute("name").Value,
                    num_brand = x.Attribute("num_brand").Value,
                    enabled = x.Attribute("enabled").Value,
                    nodePattern = x.Element("price").Element("nodePattern").Value,
                    attribute = x.Element("price").Element("attribute").Attribute("type").Value,
                    priceTreatmentEnable = x.Element("price").Element("treatment").Attribute("enabled").Value,
                    priceTreatmentType = x.Element("price").Element("treatment").Attribute("type").Value,
                    priceTreatment = x.Element("price").Element("treatment").Value,
                    titleTreatmentEnable = x.Element("title").Element("treatment").Attribute("enabled").Value,
                    titleTreatmentType = x.Element("title").Element("treatment").Attribute("type").Value,
                    titleTreatment = x.Element("title").Element("treatment").Value
                }).FirstOrDefault();
            }
        }
    }
    ​
