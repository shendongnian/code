            public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<string> stringcollection = new ObservableCollection<string>();
            stringcollection.Add("String 1");
            stringcollection.Add("String 2");
            stringcollection.Add("String 2");
            stringcollection.Add("String 3");
            customcontrol.DataContext = stringcollection;
        }
