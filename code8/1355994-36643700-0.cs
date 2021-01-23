    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication85
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement container = doc.Elements("CONTAINER").FirstOrDefault();
                string shortName = container.Element("SHORT-NAME").Value;
                List<XElement> values = container.Descendants("VALUE").ToList();
                foreach (XElement value in values)
                {
                    value.Value = shortName + "_" + value.Value;
                }
            }
        }
    }
