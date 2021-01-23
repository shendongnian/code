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
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(FILENAME1);
                XDocument doc2 = XDocument.Load(FILENAME2);
                XElement category1 = doc1.Descendants().Where(x => x.Name.LocalName == "Categories").FirstOrDefault();
                XElement category2 = doc2.Descendants().Where(x => x.Name.LocalName == "Categories").FirstOrDefault();
                category1.Add(category2.Descendants());
                XElement product1 = doc1.Descendants().Where(x => x.Name.LocalName == "Products").FirstOrDefault();
                XElement product2 = doc2.Descendants().Where(x => x.Name.LocalName == "Products").FirstOrDefault();
                product1.Add(product2.Descendants());
            }
        }
     
    }
