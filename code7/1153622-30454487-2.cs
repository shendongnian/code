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
                List<XElement> placemarks = doc.Descendants().Where(x => x.Name.LocalName == "Placemark").ToList();
                var states = placemarks.Select(x => 
                    new {
                        state = x.Descendants().Where(y => y.Name.LocalName == "name").Select(z => z.Value).FirstOrDefault(),
                        coordinates = x.Descendants().Where(y => y.Name.LocalName == "coordinates").Select(z => z.Value).ToList()
                    });
               
            }
        }
        
    }
