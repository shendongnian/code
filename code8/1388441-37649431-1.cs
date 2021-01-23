    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
     
                XmlReader xReader = XmlReader.Create(FILENAME);
                while(!xReader.EOF)
                {
                    if (xReader.Name != "Asset")
                    {
                        xReader.ReadToFollowing("Asset");
                    }
                    if (!xReader.EOF)
                    {
                        XElement assets = (XElement)XElement.ReadFrom(xReader);
                        var results = assets.Elements("TestCase").Select(x => new
                        {
                            name = (string)x.Attribute("Name"),
                            version = (string)x.Attribute("Version"),
                            subVersion = (string)x.Attribute("SubVersion")
                        }).ToList();
                     }
                }
            }
        }
    }
