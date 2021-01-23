    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Record));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Record record = (Record)xs.Deserialize(reader);
     
            }
        }
        [XmlRoot("Record")]
        public class Record
        {
            [XmlElement("File")]
            public List<File> files {get;set;}
        }
        [XmlRoot("File")]
        public class File
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlElement("Line")]
            public List<Line> lines {get;set;}
        }
        [XmlRoot("Line")]
        public class Line
        {
            [XmlAttribute("address")]
            public string address {get;set;}
            [XmlAttribute("data")]
            public string data {get;set;}
        }
    }
    ​
