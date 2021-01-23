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
                XmlSerializer xs = new XmlSerializer(typeof(LandXML));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                reader.Namespaces = false;
                LandXML landXML = (LandXML)xs.Deserialize(reader);
            }
        }
        [XmlRoot("LandXML")]
        public class LandXML
        {
            [XmlAttribute("version")]
            public double version  { get;set; }
            
            [XmlAttribute("date")]
            public DateTime date  { get;set; }
            [XmlAttribute("time")]
            public DateTime time { get; set; }
            [XmlAttribute("readOnly")]
            public Boolean readOnly  { get;set; }
            [XmlAttribute("language")]
            public string language  { get;set; }
            [XmlElement("Project")]
            public Project project { get; set; } 
            [XmlElement("Units")]
            public Units units { get; set; } 
            [XmlElement("Application")]
            public Application application { get; set; } 
            [XmlElement("Alignments")]
            public Alignments alignments { get; set; } 
    }
        [XmlRoot("Project")]
        public class Project
        {
            [XmlAttribute("name")]
            public string name;
        }
        [XmlRoot("Units")]
        public class Units
        {
            [XmlElement("Imperial")]
            public Imperial imperial { get; set; } 
        }
        [XmlRoot("Application")]
        public class Application
        {
            [XmlElement("Author")]
            public Author author { get; set; } 
        }
        [XmlRoot("Imperial")]
        public class Imperial
        {
            [XmlAttribute("linearUnit")]
            public string linearUnit;
            [XmlAttribute("areaUnit")]
            public string areaUnit;
            [XmlAttribute("volumeUnit")]
            public string volumeUnit;
            [XmlAttribute("temperatureUnit")]
            public string temperaturUnit;
            [XmlAttribute("pressureUnit")]
            public string pressureUnit;
            [XmlAttribute("angularUnit")]
            public string angularUnit;
            [XmlAttribute("directionUnit")]
            public string name;
        }
        [XmlRoot("Author")]
        public class Author
        {
            [XmlAttribute("createdBy")]
            public string createdBy;
            [XmlAttribute("createdByEmail")]
            public string createdByEmail;
            [XmlAttribute("company")]
            public string company;
            [XmlAttribute("companyURL")]
            public string companyURL;
        }
        [XmlRoot("Alignments")]
        public class Alignments
        {
            [XmlAttribute("desc")]
            public string desc;
            [XmlElement("Alignment")]
            public Alignment alignment { get; set; } 
        }
        [XmlRoot("Alignment")]
        public class Alignment
        {
            [XmlAttribute("name")]
            public string name;
            [XmlAttribute("desc")]
            public string desc;
            [XmlAttribute("length")]
            public string length;
            [XmlAttribute("staStart")]
            public string staStart;
            [XmlElement("AlignPIs")]
            public AlignPIs alignPIs { get; set; } 
        }
        [XmlRoot("AlignPIs")]
        public class AlignPIs
        {
            [XmlElement("AlignPI")]
            public List<AlignPI> alignPI { get; set; } 
        }
        [XmlRoot("AlignPI")]
        public class AlignPI
        {
            [XmlElement("PI")]
            public PI pi { get; set; } 
            [XmlElement("InSpiral")]
            public InSpiral inSpiral { get; set; } 
            [XmlElement("Curve1")]
            public Curve1 cureve1 { get; set; } 
            [XmlElement("OutSpiral")]
            public OutSpiral outSpiral { get; set; } 
            [XmlElement("Station")]
            public Station station { get; set; } 
        }
        [XmlRoot("Station")]
        public class Station
        {
            [XmlText]
            public string value { get; set; }
        }
        [XmlRoot("PI")]
        public class PI
        {
            [XmlAttribute("code")]
            public int code;
            [XmlAttribute("name")]
            public int name;
            [XmlText]
            public string value;
        }
        [XmlRoot("InSpiral")]
        public class InSpiral
        {
            [XmlElement("Spiral")]
            public Spiral spiral { get; set; } 
        }
     
        [XmlRoot("Spiral")]
        public class Spiral
        {
            [XmlAttribute("length")]
            public double length;
            [XmlAttribute("radiusEnd")]
            public double radiusEnd;
            [XmlAttribute("radiusStart")]
            public double radiusStart;
            [XmlAttribute("rot")]
            public string rot;
            [XmlAttribute("spiType")]
            public string spiType;
        }
     
        [XmlRoot("Curve1")]
        public class Curve1
        {
            [XmlElement("Curve")]
            public Curve curve { get; set; } 
        }
     
        [XmlRoot("Curve")]
        public class Curve
        {
            [XmlAttribute("rot")]
            public string rot;
            [XmlAttribute("radius")]
            public double radius;
        }
        [XmlRoot("OutSpiral")]
        public class OutSpiral
        {
            [XmlElement("Spiral")]
            public Spiral spiral { get; set; } 
        }
    }
