    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
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
                var results = doc.Descendants("LOCATION1").Elements().Select(x => new
                {
                    parent = x.Name.ToString(),
                    ip = x.Descendants("IP").Select(y => (string)y).ToList()
                }).ToList();
               
            }
        }
       
    }
    ​
