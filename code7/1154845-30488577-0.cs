    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication30
    {
        class Program
        {
            const string FILENAME = @"c:\temp\Test.xml";
            static void Main(string[] args)
            {
                FailReport failReport = new FailReport(){
                    systemDescription =  new SystemDescription(){
                            systemID = "system1",
                            reportDate = DateTime.Today,
                            specFile = "file1",
                            uut = "unit1"
                        },
                    failDescriptions = new List<FailDescription>(){
                        new FailDescription{
                            test1 = "tst1",
                            test2 = "tst2",
                            testType = "typ1",
                            component = "cmp1",
                            lowerLimit = "llimit",
                            upperLimit = "ulimit",
                            measuredValue = "value"
                        },
                        new FailDescription(){
                            test1 = "tst3",
                            test2 = "tst4",
                            testType = "typ2",
                            component = "cmp2",
                            lowerLimit = "llimit3",
                            upperLimit = "ulimit4",
                            measuredValue = "value1"
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(FailReport));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, failReport, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(FailReport));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                FailReport newFailReport = (FailReport)xs.Deserialize(reader);
            }
        }
        [XmlRoot("FailReport")]
        public class FailReport
        {
            [XmlElement("")]
            public SystemDescription systemDescription {get;set;}
            [XmlElement("")]
            public List<FailDescription> failDescriptions {get;set;}
        }
        [XmlRoot("SystemDescription")]
        public class SystemDescription
        {
            [XmlElement("")]
            public string systemID {get;set;}
            [XmlElement("")]
            public DateTime  reportDate {get;set;}
            [XmlElement("")]
            public string specFile {get;set;}
            [XmlElement("")]
            public string uut {get;set;}
        }
        [XmlRoot("FailDescription")]
        public class FailDescription
        {
            [XmlElement("Test1")]
            public string test1 {get;set;}
            [XmlElement("Test2")]
            public string test2 {get;set;}
            [XmlElement("TestType")]
            public string testType {get;set;}
            [XmlElement("Component")]
            public string component {get;set;}
            [XmlElement("LowerLimit")]
            public string lowerLimit {get;set;}
            [XmlElement("UpperLimit")]
            public string upperLimit {get;set;}
            [XmlElement("MeasuredValue")]
            public string measuredValue {get;set;}
        }
    }
