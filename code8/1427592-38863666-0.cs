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
                XElement diffgram = doc.Descendants().Where(x => x.Name.LocalName == "diffgram").FirstOrDefault();
                var results = diffgram.Descendants("r_object_id").Select(x => new {
                    r_object_id = (string)x
                }).ToList();
            }
        }
    }
