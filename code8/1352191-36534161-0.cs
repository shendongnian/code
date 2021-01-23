    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication84
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var family = doc.Descendants("node").Where(x => x.Attribute("className").Value == "Family");
                var hidden = family.Descendants("attribute").Where(x => x.Attribute("key").Value == "isHidden").FirstOrDefault();
                hidden.Attribute("value").Value = "True";
            }
        }
    }
