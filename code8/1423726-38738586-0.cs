    public ObservableCollection<String> Items { get; set; }
    //public 
    public MainWindow()
    {
        InitializeComponent();
        Items = new ObservableCollection<string>();
        Items.Add("test");
        DataContext = this;
    }
