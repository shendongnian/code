    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication65
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement _1CV8DtUD = (XElement)doc.FirstNode;
                XNamespace ns = _1CV8DtUD.Name.Namespace;
                XNamespace ns_V8 = _1CV8DtUD.GetNamespaceOfPrefix("v8");
                XNamespace ns_xsi = _1CV8DtUD.GetNamespaceOfPrefix("xsi");
                var results = _1CV8DtUD.Descendants(ns_V8 + "CatalogObject.Obj").Select(x => new {
                    isFolder = (Boolean)x.Element(ns_V8 + "IsFolder"),
                    type = (string)x.Element(ns_V8 + "Ref").Attribute(ns_xsi + "type")
                }).FirstOrDefault();
            }
        }
    }
