    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XElement reportSpec = XElement.Load(FILENAME);
                var reports = reportSpec.Elements("Report").Where(x => x.Element("Filter").Attribute("TestScore") != null).FirstOrDefault();
                int score = (int)reports.Element("Filter").Attribute("TestScore");
            }
        }
    }
