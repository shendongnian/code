    internal void RaisePropertyChanged(String propertyName)
    {
        if (PropertyChanged != null)
        {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
