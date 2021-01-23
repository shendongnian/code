    [XmlType(AnonymousType = true)]
    [XmlRootAttribute("ramowka")]
    public class Schedule
    {
        [XmlElementAttribute("dzien")]
        public ScheduleDay[] AuditionDays { get; set; }
    }
