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
                var states = placemarks.Select(x => new {
                        state = x.Descendants().Where(y => y.Name.LocalName == "name").Select(z => z.Value).FirstOrDefault(),
                        descendants = x
                    }).Select(xa => xa.descendants.Descendants().Where(x1 => x1.Name.LocalName == "MultiGeometry").Select(y => 
                    new
                    {
                      state = xa.state,
                      coordinates = xa.descendants.Descendants().Where(y1 => y1.Name.LocalName == "coordinates").Select(z => z.Value).ToList()
                    })).Where(x => x.FirstOrDefault() != null);
                var akCoordinates = states.Where(x => x.FirstOrDefault().state == "AK").Select(y => y.FirstOrDefault().coordinates);
            }
        }
        
    }
