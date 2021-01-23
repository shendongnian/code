    private ObservableCollection<OwnObject> _objects = new ObservableCollection<OwnObject>();
    public ObservableCollection<OwnObject> Objects
    {
    	get { return _objects; }
    	set { _objects = value; NotifyPropertyChanged( "Objects" ); }
    }
