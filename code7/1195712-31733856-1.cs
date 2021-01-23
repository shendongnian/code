    private ObservableCollection<ReportsModel> _Reports;
    public ObservableCollection<ReportsModel> Reports
    {
        get { return _Reports; }
        set
        { 
            _Reports = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Reports"));
            }
        }
    }
