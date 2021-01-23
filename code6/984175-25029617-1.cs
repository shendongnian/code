    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
