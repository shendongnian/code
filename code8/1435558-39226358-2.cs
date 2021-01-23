        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
        private void MyListBox_Loaded(object sender, RoutedEventArgs e)
        {
            MyListBox.ScrollIntoView(MyListBox.Items[MyListBox.Items.Count - 1]);
        }
