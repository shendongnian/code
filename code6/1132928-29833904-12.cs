    public bool? IsSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            if (value == _isSelected)
                return;
            _isSelected = value ?? false;
            OnPropertyChanged();
            OnPropertyChanged("ToggleIsSelected");
        }
    }
