    public ObservableCollection<UserData> _userDataCollection = new ObservableCollection<UserData>();
    public ObservableCollection<UserData> UserDataCollection
    {
    get { return _userDataCollection; }
    set
    {
    _userDataCollection = value;
    RaisePropertyChanged(() => UserDataCollection);
    }
    }
        
    public ICommand SaveCommand
    {
    get
    {
    //Bind UserDataCollection to your List View
    LoadDataToListView();
    }
    }
        
    private void Save()
    {
    using (var sw = new StreamWriter("output.txt"))
    {
    //load in UserDataCollection your data from textfile in here
     sw.Close();
    }
    return UserDataCollection ;
    }
