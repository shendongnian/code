    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace Calendar
    {
        class Program
        {
     
            static void Main(string[] args)
            {
            }
        }
        public class IAppointments : IAppointment
        {
            public DateTime Start { get; set; }
            public int Length { get; set; }
            public string DisplayableDescription { get; set; }
            public bool OccursOnDate(DateTime date)
            {
                return true;
            }
        }
        class Appointments : IAppointments
        {
            const string FILENAME = @"c:\temp\test.xml";
            private readonly IList<IAppointment> _list = new List<IAppointment>();
            public void Add(IAppointment item)
            {
                _list.Add(item);
            }
            public bool Load()
            {
                XmlSerializer xs = new XmlSerializer(typeof(c_Appointments));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                c_Appointments newAppointments = (c_Appointments)xs.Deserialize(reader);
                foreach (Appointment appointment in newAppointments.appointments)
                {
                    IAppointments newAppointment = new IAppointments();
                    newAppointment.Start = appointment.start;
                    newAppointment.Length = appointment.length;
                    newAppointment.DisplayableDescription = appointment.displayableDescription;
                    this.Add(newAppointment);
                }
                return true;
                
            }
            public bool Save()
            {
                 c_Appointments appointments = new c_Appointments();
                 appointments.appointments = new List<Appointment>();
                 foreach (IAppointment iAppointment in _list)
                 {
                    Appointment  newAppoint = new Appointment();
                    appointments.appointments.Add(newAppoint);
                    newAppoint = (Appointment)iAppointment;
                 }
                XmlSerializer serializer = new XmlSerializer(typeof(c_Appointments));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, appointments);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                return true;
            }
        }
        public interface IAppointment
        {
            DateTime Start { get; }
            int Length { get; }
            string DisplayableDescription { get; }
            bool OccursOnDate(DateTime date);
        }
        [XmlRoot("appointments")]
        public class c_Appointments
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
        }
    }
    ​
