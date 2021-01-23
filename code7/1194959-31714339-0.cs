    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root root = (Root)xs.Deserialize(reader);
            }
        }
        [XmlRoot("root")]
        public class Root
        {
            [XmlElement("schedule")]
            public Schedule schedule {get; set;}
        }
        [XmlRoot("schedule")]
        public class Schedule
        {
            [XmlElement("request")]
            public Request[] requests {get; set;}
        }
        [XmlRoot("request")]
        public class Request
        {
            [XmlElement("trip")]
            public List<Trip> trips {get; set;} 
        }
        [XmlRoot("trip")]
        public class Trip
        {
            [XmlAttribute("fare")]
            public string fare  { get; set; }
        }
    }
    ​
