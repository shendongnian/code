    public ObservableCollection<MyClass> gridData { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        gridData = new ObservableCollection<MyClass>();
        gvMain.ItemsSource = gridData;
    }
