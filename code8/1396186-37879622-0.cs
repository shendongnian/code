    class YourViewModel : INotifyPropertyChanged
    {
        public bool AreTimesValid
        {
            get
            {
                return StartTime < EndTime;
            }
        }
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                NotifyPropertyChanged("StartTime");
                NotifyPropertyChanged("AreTimesValid");
            }
        }
        private DateTime startTime;
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
                NotifyPropertyChanged("EndTime");
                NotifyPropertyChanged("AreTimesValid");
            }
        }
        private DateTime startTime;
    }
