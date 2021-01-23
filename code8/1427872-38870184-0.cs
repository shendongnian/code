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
                XElement dellAsset = doc.Descendants().Where(x => x.Name.LocalName == "DellAsset").FirstOrDefault();
                XNamespace ns = dellAsset.Name.Namespace;
                string customerNumber = (string)dellAsset.Element(ns + "CustomerNumber");
            }
        }
    }
