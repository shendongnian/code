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
            static void Main(string[] args)
            {
                string FILENAME = @"c:\temp\test.xml";
                Root1 root1 = new Root1() {
                    Name = "Name1",
                    Company = "Comp1",
                    Url = "site.com",
                    ElementList = new List<Element>() {
                        new Element1() {
                            Url = "site1.com",
                            Price = "15000",
                            mw = "true",
                            co = "Япония"
                        },
                        new Element2() {
                            Url = "site2.com",
                            Price = "100",
                            lg = "lg",
                            bind = "123"
                        }
                    }
                };
                
                XmlSerializer serializer = new XmlSerializer(typeof(Root1));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, root1, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root1));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root1 newRoot1 = (Root1)xs.Deserialize(reader);
                
            }
       
        }
        [XmlRoot("Root1")]
        public class Root1
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("company")]
            public string Company { get; set; }
            [XmlElement("url")]
            public string Url { get; set; }
            [XmlElement("element")]
            public List<Element> ElementList { get; set; }
        }
        [XmlInclude(typeof(Element1))]
        [XmlInclude(typeof(Element2))]
        [XmlRoot("element")]
        public class Element
        {
            [XmlElement("url")]
            public string Url { get; set; }
            [XmlElement("price")]
            public string Price { get; set; }
        }
        [XmlRoot("element1")]
        public class Element1 : Element
        {
            [XmlElement("manufacturer_warranty")]
            public string mw { get; set; }
            [XmlElement("country_of_origin")]
            public string co { get; set; }
        }
        [XmlRoot("element2")]
        public class Element2 : Element
        {
            [XmlElement("language")]
            public string lg { get; set; }
            [XmlElement("binding")]
            public string bind { get; set; }
        }
        
       
    }
