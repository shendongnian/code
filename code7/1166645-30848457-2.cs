        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
