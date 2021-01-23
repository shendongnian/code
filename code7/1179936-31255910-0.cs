    protected new virtual void OnPropertyChanged(string propertyName)
    {
        System.Diagnostics.Debug.WriteLine ("Before");
        var handler = this.PropertyChanged;
        if (handler == null)
        {
            return;
        }
        System.Diagnostics.Debug.WriteLine ("Fired");
        handler(this,
            new PropertyChangedEventArgs(propertyName));
    }
