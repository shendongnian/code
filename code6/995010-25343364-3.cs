    public MainWindow()
    {
        InitializeComponent();
        people = new ObservableCollection<Person>();
        people.Add(new Person()
                   {
                       Title = "President",
                       FullNames = new List<Names>()
                                   {
                                       new Names("George", "K", "Will")
                                   }
                   });
    }
