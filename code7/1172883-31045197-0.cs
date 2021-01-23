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
                Root root = new Root()
                {
                    itemGroup = new List<ItemGroup>() {
                         new ItemGroup(){
                             reference = new List<Reference>() {
                                 new Reference(){ include = "System"},
                                 new Reference(){ include= "System.Core"}
                             }
                         },
                         new ItemGroup(){
                             compile = new List<Compile>(){
                                 new Compile() { include = "Class1.cs"},
                                 new Compile() { include = "Properties\\AssemblyInfo.cs"}
                             }
                         }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, root);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root newRoot = (Root)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Root")]
        public class Root
        {
            [XmlElement("ItemGroup")]
            public List<ItemGroup> itemGroup { get; set; }
        }
        [XmlRoot("ItemGroup")]
        public class ItemGroup
        {
            [XmlElement("Compile")]
            public List<Compile> compile { get; set; }
            [XmlElement("Reference")]
            public List<Reference> reference { get; set; }
        }
        [XmlRoot("Compile")]
        public class Compile
        {
            [XmlAttribute("Include")]
            public string include { get; set; }
        }
        [XmlRoot("Reference")]
        public class Reference
        {
            [XmlAttribute("Include")]
            public string include { get; set; }
        }
    }
    ​
