        public Key MyKey { get; set; }
        public void MyMethod()
        {
            // do something
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyKey =  Key.F5;
        }
