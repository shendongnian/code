    class ViewModel : INotifyPropertyChanged
    {
        private string _ktimeFormat = "HH:mm:ss dd MMM yy";
        // The actual time. Similar to the "timeAll" field you have in the code now
        // Should be kept in UTC
        private DateTime _time = DateTime.UtcNow;
        // The three selected TimeZoneInfo values for the combo boxes
        private TimeZoneInfo _timeZone1 = TimeZoneInfo.Utc;
        private TimeZoneInfo _timeZone2 = TimeZoneInfo.Utc;
        private TimeZoneInfo _timeZone3 = TimeZoneInfo.Utc;
        // The text to display for each local time
        private string _localTime1;
        private string _localTime2;
        private string _localTime3;
        public ViewModel()
        {
            _localTime1 = _localTime2 = _localTime3 = _time.ToString(_ktimeFormat);
        }
        public DateTime Time
        {
            get { return _time; }
            set { UpdateValue(ref _time, value); }
        }
        public TimeZoneInfo TimeZone1
        {
            get { return _timeZone1; }
            set { UpdateValue(ref _timeZone1, value); }
        }
        public TimeZoneInfo TimeZone2
        {
            get { return _timeZone2; }
            set { UpdateValue(ref _timeZone2, value); }
        }
        public TimeZoneInfo TimeZone3
        {
            get { return _timeZone3; }
            set { UpdateValue(ref _timeZone3, value); }
        }
        public string LocalTime1
        {
            get { return _localTime1; }
            set { UpdateValue(ref _localTime1, value); }
        }
        public string LocalTime2
        {
            get { return _localTime2; }
            set { UpdateValue(ref _localTime2, value); }
        }
        public string LocalTime3
        {
            get { return _localTime3; }
            set { UpdateValue(ref _localTime3, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void UpdateValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            switch (propertyName)
            {
            case "TimeZone1":
                LocalTime1 = Convert(TimeZone1);
                break;
            case "TimeZone2":
                LocalTime2 = Convert(TimeZone2);
                break;
            case "TimeZone3":
                LocalTime3 = Convert(TimeZone3);
                break;
            case "LocalTime1":
                TryUpdateTime(LocalTime1, TimeZone1);
                break;
            case "LocalTime2":
                TryUpdateTime(LocalTime2, TimeZone2);
                break;
            case "LocalTime3":
                TryUpdateTime(LocalTime3, TimeZone3);
                break;
            case "Time":
                LocalTime1 = Convert(TimeZone1);
                LocalTime2 = Convert(TimeZone2);
                LocalTime3 = Convert(TimeZone3);
                break;
            }
        }
        private void TryUpdateTime(string timeText, TimeZoneInfo timeZone)
        {
            DateTime time;
            if (DateTime.TryParseExact(timeText, _ktimeFormat, null, DateTimeStyles.None, out time))
            {
                Time = TimeZoneInfo.ConvertTime(time, timeZone, TimeZoneInfo.Utc);
            }
        }
        private string Convert(TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTime(Time, timeZone).ToString(_ktimeFormat);
        }
    }
