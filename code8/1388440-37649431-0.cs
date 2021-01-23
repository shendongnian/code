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
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                        "<Properties>" +
                          "<Assets>" +
                            "<Asset Name=\"assetname\" Version=\"assetversion\">" +
                              "<TestCase Name=\"TCname\" Version=\"TCversion\" SubVersion=\"TCsubversion\"></TestCase>" +
                            "</Asset>" +
                            "<Asset Name=\"name\" Version=\"version\">" +
                              "<TestCase Name=\"TCname\" Version=\"TCversion\" SubVersion=\"TCsubversion\"></TestCase>" +
                            "</Asset>" +
                          "</Assets>" +
                        "</Properties>";
                StringReader reader = new StringReader(xml);
                XmlReader xReader = XmlReader.Create(reader);
                while(!xReader.EOF)
                {
                    if (xReader.Name != "Asset")
                    {
                        xReader.ReadToFollowing("Asset");
                    }
                    if (!xReader.EOF)
                    {
                        XElement asset = (XElement)XElement.ReadFrom(xReader);
                        string aName = (string)asset.Attribute("Name");
                        string aVersion = (string)asset.Attribute("Version");
                        XElement testCase = asset.Element("TestCase");
                        string tName = (string)testCase.Attribute("Name");
                        string tVersion = (string)testCase.Attribute("Version");
                        string tSubversion = (string)testCase.Attribute("SubVersion");
                    }
                }
            }
        }
    }
