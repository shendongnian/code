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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Resource resourse = new Resource();
                resourse.ReadXML(FILENAME);
            }
        }
        public class Resource
        {
            public static List<Resource> resources { get; set; }
            public string m_Name { get; set; }
            public string[] ItemDrop;
            public void ReadXML(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                resources = doc.Descendants("Resource").Select(x => new Resource() {
                    m_Name = (string)x.Attribute("name"),
                    ItemDrop = x.Element("ItemDrop").Elements("value").Select(y => (string)y).ToArray()
                }).ToList();
            }
        }
    }
