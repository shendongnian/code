    public class NotificationViewModel
    {
        public string Text { get; set; }
        public DateTime CDate { get; set; }
        public string Icon { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
        public DateTime Moment
        {
            get { return TimeZoneInfo.ConvertTimeFromUtc(CDate, TimeZoneInfo); }
        }
    }
