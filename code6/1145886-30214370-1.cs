        public bool MasterStatus
        {
            get { return masterStatus; }
            set
            {
                masterStatus = value;
                Background = masterStatus ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                OnPropertyChanged();
            }
        }
