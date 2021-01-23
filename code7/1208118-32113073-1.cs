        public ObservableCollection<string> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            items = new ObservableCollection<string>();
            items.Add("first item");
            items.Add("second item");
        }
