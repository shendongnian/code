    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication27
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(MostModule));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                MostModule MostModule = (MostModule)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Function")]
        public class Function
        {
            [XmlElement("double")]
            public List<int> m_double {get;set;}
        }
        public class SSensor
        {
            [XmlElement("ID")]
            public string Id { get; set; }
            [XmlElement("Function")]
            public Function Coefficient { get; set; }
        }
        [XmlRoot("SingleSensors")]
        public class SimpleSensor
        {
            [XmlElement("SSensor")]
            public SSensor sSensor { get; set; }
        }
        [XmlRoot("PressureSensors")]
        public class PressureSensors
        {
            [XmlElement("PSensor")]
            public SSensor sSensor { get; set; }
        }
     
        [XmlRoot("Module")]
        public class MostModule
        {
            [XmlElement("SingleSensors")]
            public SimpleSensor Sensor { get; set; }
            [XmlElement("PressureSensors")]
            public PressureSensors PressureSensor { get; set; }
      
        }
    }
