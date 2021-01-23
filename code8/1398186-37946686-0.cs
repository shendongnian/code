        private MediaFile _file;
        public MediaFile File
        {
            get { return _file; }
            set
            {
                _file = value;
                OnPropertyChanged();
            }
        }
