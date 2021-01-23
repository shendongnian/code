    using System;
    using System.Xml;
    
    namespace XmlUpdateNode
    {
        class Program
        {
            static void Main()
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"products.xml");
    
                Console.WriteLine("\n\nDisplay the initial XML...");
                xmlDoc.Save(Console.Out);
    
                // replace the price directly
                var product = xmlDoc.SelectSingleNode("descendant::product[@id='p1']/price");
                product.InnerText = "125";
    
                Console.WriteLine("\n\nDisplay the modified XML...");
                xmlDoc.Save(Console.Out);
    
                // save the document with the revised node
                xmlDoc.Save(@"products2.xml");
            }
        }
    }
