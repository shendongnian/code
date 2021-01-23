    public bool Enabled 
    {
        get { return _enabled; }
        set
        {
           if (_enabled != value)
           {
               _enabled = value;
               ScheduleChanged();
           }
           //Whatever code you need to raise the INotifyPropertyChanged.PropertyChanged event
           RaisePropertyChanged();
        }
    }
