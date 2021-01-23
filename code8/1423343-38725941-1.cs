    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication6
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                //using unique keys
                Dictionary<string, string> dict1 = doc.Descendants("mydatabase").FirstOrDefault().Elements()
                    .GroupBy(x => x.Name.LocalName, y => ((string)y).Trim())
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //when there are duplicate keys
                Dictionary<string, List<string>> dict2 = doc.Descendants("mydatabase").FirstOrDefault().Elements()
                    .GroupBy(x => x.Name.LocalName, y => ((string)y).Trim())
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
