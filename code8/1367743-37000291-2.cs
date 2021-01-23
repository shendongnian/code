    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            _isSelected = value;
            RaisePropertyChanged("IsSelected");
            ParentViewModel.RaisePropertyChanged("IsSelected");
        }
    }
