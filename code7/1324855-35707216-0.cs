    public class myTimer : INotifyPropertyChanged
    {
        private System.DateTime _duration;
        public System.DateTime Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                RaisePropertyChanged("Duration");
                RaisePropertyChanged("Remaining");
            }
        }
        private DateTime _elapsed;
        public DateTime Elapsed
        {
            get { return _elapsed; }
            set
            {
                _elapsed = value;
                RaisePropertyChanged("Elapsed");
                RaisePropertyChanged("Remaining");
            }
        }
        public System.TimeSpan Remaining
        {
            get
            {
                return Duration.Subtract(new DateTime(Duration.Year, Duration.Month, Duration.Day, Elapsed.Hour, Elapsed.Minute, Elapsed.Second));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
