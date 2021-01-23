    public void GetData()
    {
        // Also remember to plug in the correct company ID!
        // I removed the join, too, because it looks like you don't need it.
        // If you actual query is more complicated then feel free to add it back.
        var serv = (from s in _context.UserChoices
            where s.CompanyID == MySelectedItem
            select s).ToList();
        userChoices = new ObservableCollection<UserChoice>(serv);
    }
    public void GetID()
    {
       var data = _context.CompanyNames.OrderBy(o => o.CompanyID).ToList();
       CompanyNames = new ObservableCollection<CompanyName>(data);
    }
    public ObservableCollection<UserChoice> _userChoices;
    public ObservableCollection<UserChoice> userChoices 
    {
        get { return _userChoices; }
        set
        {
            _userChoices= value;
            OnPropertyChanged("userChoices ");
        }
    }
    public byte _mySelectedItem;
    public Byte MySelectedItem
    {
        get { return _mySelectedItem; }
        set
        {
            _mySelectedItem = value;
            GetData();
            OnPropertyChanged("MySelectedItem");
        }
    }
