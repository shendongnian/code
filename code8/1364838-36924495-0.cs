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
                var testid = xliff.Descendants(ns + "trans-unit").Where((x, i) => (i % 2) == 0).Select(y => new {
                       x = y.Descendants(ns + "x")
                       .Select(z => z.Attribute("id").Value)
                       .Last()
                }).ToList();
            }
        }
    }
