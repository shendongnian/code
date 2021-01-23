        Key _myKey;
        public Key MyKey
        {
            get
            {
                return _myKey;
            }
            set
            {
                _myKey = value;
                OnPropertyChanged("MyKey");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyKey = Key.OemPeriod;
        }
        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox)
                MyKey = Key.None;
            else
                MyKey = Key.OemPeriod;
        }
