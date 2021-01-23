    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                byte[] message = File.ReadAllBytes(FILENAME);
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "ECReports";
                xRoot.Namespace = "urn:epcglobal:ale:xsd:1";
                xRoot.IsNullable = true;
                XmlSerializer serializer = new XmlSerializer(typeof(ECReports), xRoot);
                MemoryStream ms = new MemoryStream(message);
                ECReports ECReports;
                ECReports = (ECReports)serializer.Deserialize(ms);
            }
        }
        [XmlRoot("ECReports")]
        public class ECReports
        {
            [XmlAttribute("specName")]
            public string specName { get; set; } 
            [XmlAttribute("date")]
            public DateTime date { get; set; } 
            [XmlAttribute("ALEID")]
            public string aleid { get; set; } 
            [XmlAttribute("totalMilliseconds")]
            public int totalMilliseconds { get; set; } 
            [XmlAttribute("terminationCondition")]
            public string terminationCondition { get; set; }
     
            [XmlElement(ElementName = "reports", Namespace = "")]
            public Reports reports { get; set; }
        
            [XmlElement(ElementName = "ECSpec", Namespace = "")]
            public ECSpec  ecSpec { get; set; }
        }
        [XmlRoot(ElementName = "reports", Namespace = "")]
        public class Reports
        {
            [XmlElement("report")]
            public Report report { get; set; }
        }    
        [XmlRoot("report")]
        public class Report
        {
            [XmlAttribute("reportName")]
            public string reportName { get; set; }
            [XmlElement("group")]
            public Group group { get; set; }
     
        }    
        [XmlRoot("group")]
        public class Group
        {
            [XmlElement("groupList")]
            public GroupList groupList { get; set; }
     
        }    
        [XmlRoot("groupList")]
        public class GroupList
        {
            [XmlElement("member")]
            public Member member { get; set; }
     
        }    
        [XmlRoot("member")]
        public class Member
        {
            [XmlElement("epc")]
            public string epc { get; set; }
        } 
       
        [XmlRoot("ECSpec", Namespace = "")]
        public class ECSpec
        {
            [XmlAttribute("includeSpecInReports")]
            public Boolean includeSpecInReports { get; set; }
            [XmlElement("logicalReaders")]
            public LogicalReaders logicalReaders { get; set; }
            [XmlElement("boundarySpec")]
            public BoundarySpec boundarySpec { get; set; }
            [XmlElement("reportSpecs")]
            public ReportSpecs reportSpecs { get; set; }
        }
        [XmlRoot("logicalReaders")]
        public class LogicalReaders
        {
            [XmlElement("logicalReader")]
            public string logicalReader { get; set; }
        }
        [XmlRoot("boundarySpec")]
        public class BoundarySpec
        {
            [XmlElement("repeatPeriod")]
            public Unit repeatPeriod { get; set; }
            [XmlElement("duration")]
            public Unit duration { get; set; }
            [XmlElement("stableSetInterval")]
            public Unit stableSetInterval { get; set; }
        }
        [XmlRoot("reportSpecs")]
        public class ReportSpecs
        {
            [XmlElement("reportSpec")]
            public ReportSpec reportSpec { get; set; }
        }
        [XmlRoot("")]
        public class Unit
        {
            [XmlAttribute("unit")]
            public string unit { get; set; }
            [XmlText]
            public int value { get; set; }
        }
        [XmlRoot("reportSpec")]
        public class ReportSpec
        {
            [XmlAttribute("reportName")]
            public string reportName { get; set; }
            [XmlAttribute("reportIfEmpty")]
            public Boolean reportIfEmpty { get; set; }
            [XmlAttribute("reportOnlyOnChange")]
            public Boolean reportOnlyOnChange { get; set; }
            [XmlElement("reportSet")]
            public ReportSet reportSet { get; set; }
            [XmlElement("output")]
            public Output output { get; set; }
        }
     
        [XmlRoot("reportSet")]
        public class ReportSet
        {
            [XmlAttribute("set")]
            public string set { get; set; }
        }
        [XmlRoot("output")]
        public class Output
        {
            [XmlAttribute("includeEPC")]
            public Boolean includeEPC { get; set; }
            [XmlAttribute("includeTag")]
            public Boolean includeTag { get; set; }
            [XmlAttribute("includeRawHex")]
            public Boolean includeRawHex { get; set; }
            [XmlAttribute("includeRawDecimal")]
            public Boolean includeRawDecimal { get; set; }
        }
     
    }
