    private void OnPropertyChanged(string propName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        if (NotifyChange != null)
            NotifyChange(this, null);
    }
