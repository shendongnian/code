    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propName));
    }
