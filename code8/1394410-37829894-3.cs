    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ReadOnlyCollection<TimeZoneInfo> TimeZones { get; }
            = TimeZoneInfo.GetSystemTimeZones();
        private TimeZoneInfo selectedTimeZone = TimeZoneInfo.Local;
        public TimeZoneInfo SelectedTimeZone
        {
            get { return selectedTimeZone; }
            set
            {
                selectedTimeZone = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("SelectedTimeZone"));
            }
        }
    }
