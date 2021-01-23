    private ObservableCollection<Whatever> _myCollection;
    public ObservableCollection<Whatever> MyCollection
    {
        get
        {
            return _myCollection;
        }
        set
        {
            if (_myCollection != value) 
            {
                _myCollection = value;
                RaisePropertyChanged("MyCollection");
            }
        }
    }
        
    private Whatever _selectedWhatever;
    public Whatever SelectedWhatever
    {
        get
        {
            return _selectedWhatever;
        }
        set
        {
            if (_selectedWhatever != value) 
            {
                _selectedWhatever = value;
                RaisePropertyChanged("SelectedWhatever");
            }
        }
    }
        
    public ClientConfig()
    {
        InitializeComponent();
        foreach (Whatever whatevs in Client.LocalDB.Values.ToObservableCollection()) 
        {
            MyCollection.Add(whatevs); // populate the collection this way and it will persist
        }
    }
