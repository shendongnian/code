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
                    "<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>" +
                    "<Site>" +
                      "<ItemData Number=\"one\" />" +
                      "<ItemData Number=\"two\" />" +
                      "<ItemData Number=\"three\" />" +
                    "</Site>";
                XDocument site = XDocument.Parse(xml);
                List<XElement> itemDatas = site.Descendants("ItemData").ToList();
                int newNumber = 3;
                foreach (XElement itemData in itemDatas)
                {
                    XAttribute number = itemData.Attribute("Number");
                    number.Value = newNumber++.ToString();
                }
            }
        }
    }
    ​
