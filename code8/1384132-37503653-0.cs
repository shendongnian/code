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
                XmlReader reader = XmlReader.Create("filename");
                while(!reader.EOF)
                {
                    if (reader.Name != "Product")
                    {
                        reader.ReadToFollowing("Product");
                    }
                    if (!reader.EOF)
                    {
                        XElement product = (XElement)XElement.ReadFrom(reader);
                        string lastUpdated = (string)product.Element("lastUpdated");
                    }
                }
            }
        }
    }
