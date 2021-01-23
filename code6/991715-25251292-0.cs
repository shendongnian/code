    using System;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SelectionCriteria criteria;
                XmlSerializer serializer = new XmlSerializer(typeof(SelectionCriteria));
                // this string should be the element you want to deserialize
                string xml =
                    "<SelectionCriteria " + 
                    "PeriodEnd=\"1\" " +
                    "PeriodEndYear=\"2\" " + 
                    "PeriodStart=\"3\" " + 
                    "PeriodStartYear=\"4\" " +
                    "SelectionEndDate=\"2014-07-31\" " +
                    "SelectionStartDate=\"2014-07-01\"/>";
                criteria = (SelectionCriteria)serializer.Deserialize(new System.IO.StringReader(xml));
            }
        }
        [XmlRoot("SelectionCriteria")]
        public class SelectionCriteria
        {
            [XmlAttribute("PeriodEnd")]
            public string PeriodEnd { get; set; }
            [XmlAttribute("PeriodEndYear")]
            public string PeriodEndYear { get; set; }
            [XmlAttribute("PeriodStart")]
            public string PeriodStart { get; set; }
            [XmlAttribute("PeriodStartYear")]
            public string PeriodStartYear { get; set; }
            [XmlAttribute("SelectionEndDate")]
            public DateTime SelectionEndDate { get; set; }
            [XmlAttribute("SelectionStartDate")]
            public DateTime SelectionStartDate { get; set; }
        }
    }
