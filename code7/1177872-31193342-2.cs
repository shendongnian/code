        private static object context;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            context = DataContext;
        }
