    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                El1 el1 = new El1()
                {
                    el2 = new El2()
                    {
                        el3 = new El3() {
                            el4 = new El4() {
                            }
                            
                        }
                    }
                };
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("u4", "http://URI4");
                ns.Add("u3", "http://URI3");
                ns.Add("u2", "http://URI2");
                ns.Add("", "http://URI1");
                XmlSerializer serializer = new XmlSerializer(typeof(El1));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, el1, ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlRoot("el1", Namespace = "http://URI1")]
        public class El1
        {
            [XmlElement("el2", Namespace = "http://URI2")]
            public El2 el2 { get; set; }
        }
        [XmlRoot("el2")]
        public class El2
        {
            [XmlElement("el3", Namespace = "http://URI3")]
            public El3 el3 { get; set; }
        }
        [XmlRoot("el3", Namespace = "http://URI3")]
        public class El3
        {
            [XmlElement("el4", Namespace = "http://URI4")]
            public El4 el4 { get; set; }
        }
        [XmlRoot("el4", Namespace = "http://URI1")]
        public class El4
        {
        }
    }
    ​
