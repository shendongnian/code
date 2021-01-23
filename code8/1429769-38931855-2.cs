    public class NotificationViewModel
    {
        private TimeZoneInfo _TimeZoneInfo; // or this could be a public property
        public NotificationViewModel() { } // parameterless constructor
        public NotificationViewModel(TimeZoneInfo timeZoneInfo)
        {
            _TimeZoneInfo = timeZoneInfo;
        }
        public NotificationViewModel() {} // parameterless constructor
        public string Text { get; set; }
        public DateTime CDate { get; set; }
        public string Icon { get; set; }
        public DateTime Moment
        {
            get { return TimeZoneInfo.ConvertTimeFromUtc(CDate, _TimeZoneInfo); }
        }
    }
