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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Element("parent").Elements().Select(x => new
                {
                    name = x.Name,
                    property1 = x.Attribute("property1").Value,
                    property2 = x.Attribute("property2").Value,
                    child_property1 = x.Element("optionalchild") == null ? null : x.Element("optionalchild").Attribute("property1").Value,
                    child_property2 = x.Element("optionalchild") == null ? null : x.Element("optionalchild").Attribute("property2").Value
                }).ToList();
            }
        }
    }
    ​
