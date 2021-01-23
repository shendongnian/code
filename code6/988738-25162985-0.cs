    public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
         if (PropertyChanged != null)
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
    }
