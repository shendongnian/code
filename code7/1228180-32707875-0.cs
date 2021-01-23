    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Root root = new Root() {
                    bar = new Bar1() {
                        foo = "123"
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, root, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlRoot("Root")]
        public class Root 
        {
            public Bar bar {get;set;}
        }
        [XmlInclude(typeof(Bar1))]
        [XmlRoot("Bar")]
        public class Bar 
        {
        }
        [XmlRoot("Bar1")]
        public class Bar1 : Bar
        {
            [XmlElement("foo")]
            public string foo {get;set;}
        }
    }
