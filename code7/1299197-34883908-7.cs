    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace StackOverflow
    {
        public class Call
        {
            [XmlIgnore]
            public int ID { get; set; }
            [XmlIgnore]
            public string CustomerInitials { get; set; }
            [XmlIgnore]
            public string Prefix { get; set; }
            [XmlIgnore]
            public string Code { get; set; }
            [XmlIgnore]
            public string CustomerNumber { get; set; }
    
            [XmlElement("CNUMBER")]
            public string Number
            {
                get { return Prefix + Code + CustomerNumber; }
            }
            [XmlElement("STARTTIME")]
            public DateTime Entry { get; set; }
            [XmlElement("ENDTIME")]
            public DateTime Exit { get; set; }
        }
    
        [XmlRoot(ElementName = "DATA")]
        public class Data
        {
            [XmlElement("RECORD")]
            public List<Call> Calls;
        }
    }
