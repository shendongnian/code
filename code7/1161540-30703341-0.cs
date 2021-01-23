    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlMetadata data = new XmlMetadata(){
                    elemements = new List<Element>(){
                        new Element(){ name = "cert", value = "0001"},
                        new Element(){ name = "model", value = "Test"},
                        new Element(){ name = "created", value = "2015-05-21"}
                    }    
                };
                XmlSerializer serializer = new XmlSerializer(typeof(XmlMetadata));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("md", "http://example.com/metadata");
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, data, ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(XmlMetadata));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                XmlMetadata newData = (XmlMetadata)xs.Deserialize(reader);
            }
        }
        [XmlRootAttribute(ElementName = "Metadata", Namespace = "http://example.com/metadata", IsNullable = false)]
        public class XmlMetadata
        {
            [XmlElement(ElementName = "Element", Namespace = "http://example.com/metadata", IsNullable = false)]
            public List<Element> elemements { get; set; }
        }
        [XmlRootAttribute(ElementName = "Element", Namespace = "http://example.com/metadata", IsNullable = false)]
        public class Element
        {
            [XmlAttribute(AttributeName = "name",Namespace = "http://example.com/metadata")]
            public string name {get; set; }
            [XmlAttribute(AttributeName = "value", Namespace = "http://example.com/metadata")]
            public string value { get; set; } 
        }
    }
    ​
    ​
