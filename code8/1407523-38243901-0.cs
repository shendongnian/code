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
                //more than one value per key
                Dictionary<string, List<string>> dict1 = doc.Descendants("item").First().Elements("item")
                    .GroupBy(x => x.Element("key").Value, y => y.Element("value").Value)
                    .ToDictionary(x => x.Key, y => y.ToList());
                //one value per key
                Dictionary<string, string> dict2 = doc.Descendants("item").First().Elements("item")
                    .GroupBy(x => x.Element("key").Value, y => y.Element("value").Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
