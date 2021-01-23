    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Calendar
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //add to appointments to object below
                Appointments appointments = new Appointments()
                {
                    appointments = new List<Appointment>() {
                        new Appointment(){ start = DateTime.Today, length = 2, displayableDescription = "Meeting wiith Joe", occursOnDate = true},
                        new Appointment(){ start = DateTime.Today.AddDays(2), length = 3, displayableDescription = "Meeting wiith Jane", occursOnDate = false}
                    }
                };
                //use this code for writing
                XmlSerializer serializer = new XmlSerializer(typeof(Appointments));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, appointments);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                //use this code for reading
                XmlSerializer xs = new XmlSerializer(typeof(Appointments));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Appointments newAppointments = (Appointments)xs.Deserialize(reader);
            }
        }
        [XmlRoot("appointments")]
        public class Appointments
        {
            [XmlElement("appointment")]
            public List<Appointment> appointments { get; set; }
        }
        [XmlRoot("appointment")]
        public class Appointment
        {
            [XmlElement("start")]
            public DateTime start { get; set; }
            [XmlElement("length")]
            public int length { get; set; }
            [XmlElement("displayableDescription")]
            public string displayableDescription { get; set; }
            [XmlElement("occursOnDate")]
            public bool occursOnDate { get; set; }
        }
    }
