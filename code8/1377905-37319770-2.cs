    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            const string XML_INPUT = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(XML_INPUT);
                XNamespace bNS = "PricingCommonAPI";
                while(!reader.EOF)
                {
                    if(reader.Name != "HotelSearchResult")
                    {
                        reader.ReadToFollowing("HotelSearchResult", bNS.NamespaceName);
                    }
                    if(!reader.EOF)
                    {
                        XElement hotelSearchResult = (XElement)XElement.ReadFrom(reader);
                    }
                }
            }
        }
    }
