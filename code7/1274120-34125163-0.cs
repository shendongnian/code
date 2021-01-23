    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.XPath;
    using System.Xml.Linq;
    using System.Xml;
    
    namespace Test
    {
        class Program
        {
            static int Main(string[] args)
            {
                String xml = "<h3>Blah blah<sup><a>1</a></sup></h3>";
                XDocument xDoc = XDocument.Parse(xml);
                var h3 = xDoc.XPathSelectElement("//h3");
                Console.WriteLine(h3.DescendantNodes().First());
                return 1;
            }
    
        }
    }
