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
                Facility facility = new Facility() {
                    Id = 353,
                    Name = "Test",
                    CategoryID = "Test",
                    SMSInfoID = new SMSInfoID() {
                            ID = new List<ID>() {
                                new ID() { _default = true, value = 140},
                                new ID() { _default = true, value = 140},
                                new ID() { _default = true, value = 140}
                            }
                        }
                    };
                XmlSerializer serializer = new XmlSerializer(typeof(Facility));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, facility);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                               
            }
        }
        public class Facility
        {
            [XmlAttribute("ID")]
            public int Id { get; set; }
            [XmlElement("Buildingtype")]
            public string CategoryID { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("SMSInfoID")]
            public virtual SMSInfoID SMSInfoID { get; set; }
        }
        [XmlRoot("SMSInfoID")]
        public class SMSInfoID
        {
            [XmlElement("ID")]
            public List<ID> ID { get; set; }
        }
        [XmlRoot("ID")]
        public class ID
        {
            [XmlAttribute("default")]
            public Boolean _default {get; set;}
            [XmlText()]
            public int value { get; set; }
        }
    }
 
