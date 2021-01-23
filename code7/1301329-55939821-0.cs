    public ObservableCollection<ITimeLineDataItem> SlideDataItems { 
        get { return _slideDataItems; }
        set
        {
            _slideDataItems = value;
            OnPropertyChanged("SlideDataItems");
        }
    }
    private ObservableCollection<ITimeLineDataItem> _slideDataItems = new ObservableCollection<ITimeLineDataItem>();
