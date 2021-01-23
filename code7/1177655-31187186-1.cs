    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                MainDatas mainDatas = new MainDatas() {
                    contains = new MainDatasContains() {
                        featureCollection = new FeatureCollection(){
                            id = "UHL",
                            boundedBy = 999.9,
                            featureMembers = new List<FeatureMember>() {
                                new FeatureMember() {
                                    myClass1 = new MyClass1() {
                                        id = "XXX0001"
                                    }
                                },
                                new FeatureMember() {
                                    myClass2 = new MyClass2() {
                                        id = "XXX0001"
                                    }
                                },
                                new FeatureMember() {
                                    myClass1 = new MyClass1() {
                                        id = "XXX0003"
                                    }
                                }
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(MainDatas));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("aan", "http://www.andAnotherNamespace.com/");
                ns.Add("ons", "http://www.myOtherNamespace.com/");
                ns.Add("", "http://www.myNamespace.com/");
     
                serializer.Serialize(writer, mainDatas, ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(MainDatas));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                MainDatas newMainDatas = (MainDatas)xs.Deserialize(reader);
            }
        }
        [XmlRoot("mainDatas", Namespace = "http://www.myNamespace.com/")]   
        public class MainDatas
        {
            [XmlElement("contains")]
            public MainDatasContains contains { get; set; }
        }
        [XmlRoot("contains")]
        public class MainDatasContains
        {
            [XmlElement("FeatureCollection", Namespace = "http://www.myOtherNamespace.com/")]
            public FeatureCollection featureCollection { get; set; }
        }
        [XmlRoot(ElementName = "FeatureCollection")]
        public class FeatureCollection
        {
            [XmlAttribute("id", Namespace = "http://www.andAnotherNamespace.com/")]
            public string id { get; set; }
            [XmlElement("boundedBy", Namespace = "http://www.andAnotherNamespace.com/")]
            public double boundedBy { get; set; }
            [XmlElement("featureMember", Namespace = "http://www.andAnotherNamespace.com/")]
            public List<FeatureMember> featureMembers { get; set; }
        }
        [XmlRoot("featureMember")]
        public class FeatureMember
        {
            [XmlElement("myClass1")]
            public MyClass1 myClass1 { get; set; }
            [XmlElement("myClass2")]
            public MyClass2 myClass2 { get; set; }
        }
        [XmlRoot("myClass1")]
        public class MyClass1
        {
            [XmlAttribute("id", Namespace = "http://www.andAnotherNamespace.com/")]
            public string id { get; set; }
        }
        [XmlRoot("myClass2")]
        public class MyClass2
        {
            [XmlAttribute("id")]
            public string id { get; set; }
        }
    }
    ​
