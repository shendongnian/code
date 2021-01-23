    [DataContract]
    public class ScheduleDay
    {
        [DataMember, XmlAttribute]
        public string name { get; set; }
        [DataMember, XmlAttribute]
        public string count { get; set; }
    }
    [DataContract]
    public class Schedule
    {
        [DataMember]
        public ScheduleDay ScheduleDay { get; set; }
    }
