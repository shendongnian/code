    public void onPropertyChanged(string property)
    {
        var _PropertyChanged = PropertyChanged;
        if (_PropertyChanged != null)
            _PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
