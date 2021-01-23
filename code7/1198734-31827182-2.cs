    public ObservableCollection<Object> coll { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        coll = new ObservableCollection<Object>();
        Object uc1 = new UserControl1();
        Object uc2 = new UserControl2();
        coll.Add(uc1);
        coll.Add(uc2);
        tab1.ItemsSource = coll;
    }
