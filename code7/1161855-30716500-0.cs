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
                XmlSerializer serializer = new XmlSerializer(typeof(TestConfiguration));
                StreamReader reader = new StreamReader(FILENAME);
                TestConfiguration _testConfig = (TestConfiguration)serializer.Deserialize(reader);
                reader.Close();
            }
        }
        [XmlRoot("TestConfiguration")]
        public class TestConfiguration
        {
            private string _barcode;
            private string[] _testSuites;
            private string[] _testcase;
            //Product barcode
            [XmlElement("Barcode")]
            public string Barcode { get; set; }
            //Test suites
            [XmlElement("TestSuites")]
            public TestSuites testSuites { get; set; }
        }
        //individual test
        [XmlRoot("TestSuites")]
        public class TestSuites
        {
            [XmlElement("Test")]
            public List<string> test {get;set;}
        }
    }
    ​
