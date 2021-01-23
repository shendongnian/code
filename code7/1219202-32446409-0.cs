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
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                TimeEntries timeEntries = new TimeEntries()
                {
                    timeEntry = new List<TimeEntry>() {
                        new TimeEntry() {},
                        new TimeEntry() {},
                        new TimeEntry() {}
                    }
                };
                TimeTotalsResponse timeTotals = new TimeTotalsResponse()
                {
                    TotalMinsSum = new TypeInteger() { _type = "integer", _value = 382743 },
                    NonBilledMinsSum = new TypeInteger() { _type = "integer", _value = 328988 },
                    NonBillableHoursSum = new TypeInteger() { _type = "integer", _value = 3137.30 }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(TimeEntryResponse));
                StreamWriter writer = new StreamWriter(FILENAME1);
                serializer.Serialize(writer, timeEntries);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                serializer = new XmlSerializer(typeof(TimeEntryResponse));
                writer = new StreamWriter(FILENAME2);
                serializer.Serialize(writer, timeTotals);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlInclude(typeof(TimeEntries))]
        [XmlInclude(typeof(TimeTotalsResponse))]
        [Serializable]
        public class TimeEntryResponse
        {
            
        }
        [XmlRoot("time-entries")]
        public class TimeEntries : TimeEntryResponse
        {
            [XmlElement("time-entry")]
            public List<TimeEntry> timeEntry { get; set; }
        }
        [XmlRoot("time-entry")]
        public class TimeEntry
        {
        }
        [XmlRoot("time-totals")]
        public class TimeTotalsResponse : TimeEntryResponse
        {
            [XmlElement("total-mins-sum")]
            public TypeInteger  TotalMinsSum { get; set; }
            [XmlElement("non-billed-mins-sum")]
            public TypeInteger NonBilledMinsSum { get; set; }
            [XmlElement("non-billable-hours-sum")]
            public TypeInteger NonBillableHoursSum { get; set; }
        }
        public class TypeInteger
        {
            [XmlAttribute("type")]
            public string _type { get; set; }
            [XmlText]
            public double _value { get; set; }
        }
    }
    ​
