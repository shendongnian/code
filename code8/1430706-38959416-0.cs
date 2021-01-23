    private IList _selectedTestModels;
    public IList SelectedTestModels
    {
        get { return _selectedTestModels; }
        set
        {
            _selectedTestModels = value;
            OnPropertyChanged();
        }
    }
