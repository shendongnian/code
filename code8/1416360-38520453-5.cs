    class ViewModel : INotifyPropertyChanged
    {
        // The actual time. Similar to the "timeAll" field you have in the code now
        // Should be kept in UTC
        private DateTime _time;
        // The three selected TimeZoneInfo values for the combo boxes
        private TimeZoneInfo _timeZone1;
        private TimeZoneInfo _timeZone2;
        private TimeZoneInfo _timeZone3;
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
        public event PropertyChangedEventHandler PropertyChanged;
        private void UpdateValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                field = value;
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
