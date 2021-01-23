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
                List<XElement> containers = doc.Elements("CONTAINER");
                foreach (XElement container in containers)
                {
                    string shortName = (string)container.Element("SHORT-NAME");
                    if (shortName.Length > 0)
                    {
                        List<XElement> values = container.Descendants("FUNCTION-NAME-VALUE").Descendants("VALUE").ToList();
                        foreach (XElement value in values)
                        {
                            value.Value = shortName + "_" + value.Value;
                        }
                    }
                }
            }
        }
    }
