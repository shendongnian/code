    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            SelectedTimeZone = TimeZones[0];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ReadOnlyCollection<TimeZoneInfo> TimeZones { get; }
            = TimeZoneInfo.GetSystemTimeZones();
        private TimeZoneInfo selectedTimeZone;
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
