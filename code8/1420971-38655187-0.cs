    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                string id = "UMTS900";
                object coverages = null;
                while (!reader.EOF)
                {
                    if (reader.Name != "Tech")
                    {
                        reader.ReadToFollowing("Tech");
                    }
                    if (!reader.EOF)
                    {
                        XElement tech = (XElement)XElement.ReadFrom(reader);
                        if((string)tech.Attribute("ID") == "UMTS900")
                        {
                            coverages = tech.Descendants("Coverage").Select(x => new
                            {
                                id = (string)x.Attribute("ID"),
                                downLoad_Speed = (int)x.Element("DownLoad_Speed"),
                                upLoad_Speed = (int)x.Element("Upload_Speed"),
                            }).ToList();
                            break;
                        }
                    }
                }
     
     
            }
        }
    }
