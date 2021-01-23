            private bool _tabIsEnabled;
        private string _content;
        public bool TabIsEnabled
        {
            get { return _tabIsEnabled; }
            set
            {
                _tabIsEnabled = value;
                OnPropertyChanged();
            }
        }
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
