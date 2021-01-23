    public void NotifyPropertyChange(string propName)
    {
        var handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propName));
    }
