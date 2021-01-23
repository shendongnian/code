    public partial class SmsSchedule
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        [ForeignKey("SiteId")]
        public virtual Site Site { get; set; }
    
        public int ScheduleTypeId { get; set; }
        [ForeignKey("ScheduleTypeId ")]
        public virtual SmsScheduleType SmsScheduleType { get; set; }
    
        public int DateToSend { get; set; }
        public int DayOfWeekToSend { get; set; }
        public string TimeToSend { get; set; }
        public string TextToSend { get; set; }
        public int Interval { get; set; }
    }
