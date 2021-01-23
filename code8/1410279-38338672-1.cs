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
    
                // replace the node with a new one
                //Select the profile node with the matching attribute value.
                var product = xmlDoc.SelectSingleNode("descendant::product[@id='p1']");
    
                //Create a new price element.
                XmlElement elem = xmlDoc.CreateElement("price");
                elem.InnerText = "125";
    
                //Replace the price element.
                product.ReplaceChild(elem, product.FirstChild.NextSibling);
                Console.WriteLine("\n\nDisplay the modified XML...");
                xmlDoc.Save(Console.Out);
    
                // save the document with the revised node
                xmlDoc.Save(@"products2.xml");
            }
        }
    }
