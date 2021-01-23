    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<AssemblyVerwaltung> List_AssemblyVerwaltung = new List<AssemblyVerwaltung>();
                Root root = new Root();
                root.List_AssemblyVerwaltung = new List<AssemblyVerwaltung>(List_AssemblyVerwaltung);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, root, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root  newRoot = (Root)xs.Deserialize(reader);
            }
            
        }
        [XmlRoot("Root")]
        public class Root
        {
            [XmlElement("List_AssemblyVerwaltung")]
            public List<AssemblyVerwaltung> List_AssemblyVerwaltung  { get; set; }
        }
        [XmlRoot("List_AssemblyVerwaltung")]
        public class AssemblyVerwaltung
        {
            [XmlElement("AssemblyName")]
            public string AssemblyName {get;set;}
            [XmlElement("List_KlassenNamen")]
            public List<string> List_KlassenNamen {get;set;}
        }
     
    }
