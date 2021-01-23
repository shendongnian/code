    private ObservableCollection<HistoryRow> _historyData;
    public ObservableCollection<HistoryRow> HistoryData 
    { 
        get {return _historyData}
        set {_historyData = value; OnPropertyChange("HistoryData");}
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
