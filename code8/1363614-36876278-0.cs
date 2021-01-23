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
                XElement trkseg = doc.Descendants().Where(x => x.Name.LocalName == "trkseg").FirstOrDefault();
                XNamespace ns = trkseg.Name.Namespace;
                var l_l = trkseg.Elements(ns + "trkpt").Select(x => new
                {
                    lat = x.Attribute("lat").Value,
                    lon = x.Attribute("lon").Value
                }).ToList();
            }
        }
    }
