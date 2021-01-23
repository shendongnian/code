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
             
                XElement doc = XElement.Load(FILENAME);
                XElement p = doc.Descendants().Where(x => x.Name.LocalName == "p").FirstOrDefault();
                XAttribute name = p.Attributes().Where(x => x.Name.LocalName == "style-name").FirstOrDefault();
                name.Value = "new value";
                doc.Save(FILENAME);
            }
        }
    }
