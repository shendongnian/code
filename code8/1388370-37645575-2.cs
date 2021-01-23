    public ObservableSortedSet<String> Values { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Values = new ObservableSortedSet<string>();
            Values.Add("Test0");
            Values.Add("Test1");
            Values.Add("Test2");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Values.Add("Test" + Values.Count);
        }
    }
