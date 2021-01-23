    public ObservableCollection<string> MonthsToSkip 
    { 
        get { return _monthsToSkip; }
        set { _monthsToSkip = value; OnPropertyChanged("MonthsToSkip"); } 
    }
    public ObservableCollection<string> _monthsToSkip;
