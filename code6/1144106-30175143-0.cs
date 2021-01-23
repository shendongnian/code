    private string[] _optionItems;
    public string[] OptionItems
    {
        get
        {
            return _optionItems;
        }
        set
        {
            if (_optionItems == value)
                return;
            _optionItems = value;
            OnPropertyChanged();
        }
    }
    private string _selectedOption;
    public string SelectedOption
    {
        get
        {
            return _selectedOption;
        }
        set
        {
            if (_selectedOption == value)
                return;
            _selectedOption = value;
            OnPropertyChanged();
        }
    }
