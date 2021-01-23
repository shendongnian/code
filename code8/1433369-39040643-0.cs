    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication9
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement directory = doc.Descendants().Where(x => x.Name.LocalName == "directory-entries").FirstOrDefault();
                XNamespace ns = directory.Name.Namespace;
                var results = doc.Descendants(ns + "directory-entries").Select(x => new
                {
                    dn = (string)x.Element(ns + "entry").Attribute("dn"),
                    ocValue = x.Descendants(ns + "oc-value").Select(y => (string)y).ToList(),
                    attr = x.Descendants(ns + "attr").Select(y => new {
                        name = (string)y.Attribute("name"),
                        value = (string)y.Element(ns + "value")
                    }).ToList()
               }).FirstOrDefault();
            }
        }
    }
