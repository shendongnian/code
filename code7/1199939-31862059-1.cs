    private ObservableCollection<LogItem> _logItems;
    public ObservableCollection<LogItem> LogItems
    {
        get { return _logItems; }
        set
        {
            _logItems = value;
            NotifyPropertyChanged("LogItems");
        }
    }
