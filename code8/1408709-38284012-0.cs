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
                var xnList = doc.Descendants("question").Select(x => new
                {
                    num = (int)x.Attribute("num"),
                    text = x.Value
                }).ToList();
                foreach (var question in xnList)
                {
                }
            }
        }
    }
 
