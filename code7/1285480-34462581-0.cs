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
                    "<Location>" +
                        "<AChau>" +
                            "<ACity>" +
                              "<EHouse/>" +
                              "<FHouse/>" +
                              "<GHouse/>" +
                            "</ACity>" +
                            "<BCity>" +
                              "<HHouse/>" +
                              "<IHouse/>" +
                              "<JHouse/>" +
                              "<KHouse/>" +
                            "</BCity>" +
                        "</AChau>" +
                    "</Location>";
                XElement location = XElement.Parse(xml);
                var results = location.Descendants("AChau").Elements().Select(x => new
                {
                    city = x.Name.LocalName,
                    houses = string.Join(",",x.Elements().Select(y => y.Name.LocalName).ToArray())
                }).ToList();
            }
        }
    }
    ​
