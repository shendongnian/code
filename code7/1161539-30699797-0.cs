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
                XmlMetadata data = new XmlMetadata()
                {
                    cert = "0001",
                    model = "Test",
                    created = DateTime.Parse("2015-05-21")
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
           [XmlElement(ElementName = "Cert", Namespace = "http://example.com/metadata", IsNullable = false)]
           public string cert {get;set;}
           [XmlElement(ElementName = "Model", Namespace = "http://example.com/metadata", IsNullable = false)]
           public string model {get;set;}
           [XmlElement(ElementName = "Created", Namespace = "http://example.com/metadata", IsNullable = false)]
           public DateTime created {get;set;}
        }
    }
    ​
