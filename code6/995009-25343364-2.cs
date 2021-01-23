    public MainWindow()
    {
        InitializeComponent();
        people = new ObservableCollection<Person>();
        Person toAdd = new Person();
        toAdd.Title = "President";
        toAdd.FullNames = new List<Names>();
        toAdd.FullNames.Add(new Names(First = "George", Middle = "K", Last = "Will"));
        people.Add(toAdd);
    }
