<!-- language: lang-css --
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
                List<XElement> ss = doc.Descendants().Where(x => x.Attribute("social_security_number") != null).ToList();
                foreach (XElement s in ss)
                {
                    s.Attribute("social_security_number").Value = "Scrubbed";
                }
            }
        }
    }
