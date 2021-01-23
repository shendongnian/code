    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication25
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                ArrayOfData newArrayOfData = (ArrayOfData)xs.Deserialize(reader);
            }
     
        }
        [XmlRoot("ArrayOfData")]
        public class ArrayOfData
        {
            [XmlElement("data")]
            public List<data> c_Data { get; set; }
        }
        [XmlRoot("data")]
        public class data
        {
            [XmlElement("project_name")]
            public string project_name { get; set; }
            [XmlElement("note_text")]
            public string note_text { get; set; }
            [XmlElement("tag_text")]
            public string tag_text { get; set; }
            [XmlElement("start_date")]
            public DateTime start_date { get; set; }
            [XmlElement("due_date")]
            public DateTime due_date { get; set; }
            [XmlElement("action")]
            public string action { get; set; }
        }
    }
