    public MainWindow()
    {
        InitializeComponent();
        people = new ObservableCollection<Person>();
        people.Add(new TodoItem() {
                       Title = "President",
                       FullNames = new List<Names>() { new Names(First = "George",
                                                                 Middle = "K",
                                                                 Last = "Will")} });
    }
