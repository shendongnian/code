    ViewModelBase _currentContent;
    public ViewModelBase CurrentContent
    {
        get { return _currentContent; }
        set
        {
            _currentContent = value;
            RaisePropertyChanged(nameof(CurrentContent));
        }
    }
