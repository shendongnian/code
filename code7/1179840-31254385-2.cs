        public Data data;
        public MainWindow()
        {
            InitializeComponent();
            data = new Data();
            this.DataContext = data;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Random = new Random().Next(1000);
        }
