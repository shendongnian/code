        DemonstrationViewModel demoViewModel;
        public MainWindow()
        {
            InitializeComponent();
            demoViewModel = new DemonstrationViewModel();
            DataContext = demoViewModel;
        }
        private void alsoDemoButton_Click(object sender, RoutedEventArgs e)
        {
            demoViewModel.EnteredCode += "Clicked";
        }
