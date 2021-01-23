    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        ObservableCollection<int> test = new ObservableCollection<int>();
        test.Add(1);
        test.Add(123232);
        Test = test;
    }
    public ObservableCollection<int> Test { get; set; }
