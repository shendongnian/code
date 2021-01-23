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
            static void Main(string[] args)
            {
                StringBuilder sb2 = new System.Text.StringBuilder();
                sb2.AppendLine(@"<MetalQuote xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.xignite.com/services"" >");
                sb2.AppendLine(@"<Outcome>Success</Outcome>");
                sb2.AppendLine(@"<Ask>1073.3</Ask>");
                sb2.AppendLine(@"</MetalQuote>");
                XDocument doc = XDocument.Parse(sb2.ToString());
                XElement outCome = doc.Descendants().Where(x => x.Name.LocalName == "Outcome").FirstOrDefault();
                XElement metalQuote = (XElement)doc.FirstNode;
                XNamespace ns = metalQuote.Name.Namespace;
                XElement outCome2 = doc.Descendants(ns + "Outcome").FirstOrDefault();
                
            }
        }
    }
    ​
