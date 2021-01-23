    bool _isEditMode;
    public bool IsEditMode
    {
        get { return _isEditMode; }
        set
        {
            _isEditMode = value;
            OnPropertyChanged(nameof(IsEnabled)); // update IsEnabled when IsEditMode changed
        }
    }
    bool _isEnabled;
    public bool IsEnabled
    {
        get
        {
            return IsEditMode || _isEnabled; // return true if IsEditMode == true or actual value otherwise
        }
        set
        {
            _isEnabled = value;
            OnPropertyChanged();
        }
    }
