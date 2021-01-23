    protected ObservableCollection<string> _SavedMachines = new ObservableCollection<string>();
    public ObservableCollection<string> SavedMachines
    {
        get { return _SavedMachines; }
        set
        {
            if (_SavedMachines != value) 
            {
              _SavedMachines = value;
              NotifyPropertyChanged("SavedMachines");
            }
        }
    }  
