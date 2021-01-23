    private bool _isExpanded;       
    public bool IsExpanded
    {
        get
        {
            return _isExpanded;
        }
        set
        {
            _isExpanded = value;
            OnPropertyChanged("IsExpanded");
        }
    }
