    private T _selectedItem;
    public T SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            if(value != _selectedItem)
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
    }
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => RaisePropertyChanged(propertyName);
