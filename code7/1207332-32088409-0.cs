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
                var results = doc.Descendants().Where(x => x.Name.LocalName == "Parameter").Descendants().Where(y => y.Name.LocalName == "Property").Select(z => new
                {
                    value = z.Attributes().Where(a => a.Name.LocalName == "Name").Select(b => b.Value).FirstOrDefault()
                }).ToList();
                foreach (var item in results)
                {
                    Console.WriteLine(item.value);
                }
            }
        }
    }
    ​
