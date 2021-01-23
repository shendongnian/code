    [Serializable()]
        [XmlType(AnonymousType = true, Namespace = "")]
        public class AppointmentAvailabilityStatusResult : WebserviceMessage
        {
            [XmlElement("DateAndTimeSlot", Namespace = "Appointments")]
            public DateAndTimeSlot DateAndTimeSlot { get; set; }
    
            [XmlElement("RequestedStatus")]
            public int RequestedStatus { get; set; }
        }
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = "Appointments")]
        [XmlRoot(ElementName = "DateAndTimeSlot",Namespace = "Appointments", IsNullable = false)]
        public class DateAndTimeSlot
        {
            [XmlElement(ElementName = "DateAndTimeslot", Namespace = "Appointments.TO")]
            public List<DateAndTimeslot> DateAndTimeslot { get; set; }
        }
    
        [Serializable()]
        [XmlType(AnonymousType = true, Namespace = "Appointments.TO")]
        [XmlRoot(Namespace = "Appointments.TO", IsNullable = false)]
        public class DateAndTimeslot
        {
            [XmlElement("Date")]
            public string Date { get; set; }
            [XmlElement("TimeSlot")]
            public string TimeSlot { get; set; }
        }
