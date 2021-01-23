    private YourType _selectedResult;
    public YourType SelectedResult
    {
        get { return _selectedResult; }
        set { _selectedResult= value; OnPropertyChanged("SelectedResult"); }
    }
