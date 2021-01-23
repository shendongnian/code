    public MainWindow()
    {
        InitializeComponent();
        people = new ObservableCollection<Person>();
        Person toAdd = new Person();
        toAdd.Title = "President";
        toAdd.FullNames = new List<Names>();
        toAdd.FullNames.Add(new Names("George", "K", "Will"));
        people.Add(toAdd);
    }
