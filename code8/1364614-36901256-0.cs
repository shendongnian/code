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
                XElement xliff = (XElement)doc.FirstNode;
                XNamespace ns = xliff.Name.Namespace;
                var testid = xliff.Descendants(ns + "trans-unit")
                    .Where(x => x.Element(ns + "target") == null)
                    .Descendants(ns + "x")
                    .Select(y => y.Attribute("id").Value)
                    .Last();
                    
            }
        }
    }
