        public ObservableCollection<FileProcessing_T> FileProcessing 
        {
            get
            {
                return _fileProcessing;
            }
            set
            {
                if (_fileProcessing != value)
                {
                    _fileProcessing = value;
                    RaisePropertyChanged("FileProcessing");
                }
            }
        }
        ObservableCollection<FileProcessing_T> _fileProcessing;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
