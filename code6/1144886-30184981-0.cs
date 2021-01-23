    public ObservableCollection<dynamic> SampleListData
        {
            get { return _sampleListData; }
            set { _sampleListData = value; NotifyPropertyChanged("SampleListData"); }
        }
