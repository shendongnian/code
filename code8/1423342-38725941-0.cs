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
                Dictionary<string, string> dict = doc.Descendants("mydatabase").FirstOrDefault().Elements()
                    .GroupBy(x => x.Name.LocalName, y => ((string)y).Trim())
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
