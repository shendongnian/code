    private ObservableCollection<Location> _allLocations;
    public ObservableCollection<Location> AllLocations
    {
        get { return _allLocations; }
        set { _allLocations = value; RaisePropertyChanged("AllLocations"); }
    }
    public ViewModel1(ViewModel2 vm2 )
    {
            
        AllLocations = vm2.Locations;
    }
