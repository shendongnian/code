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
        public ICommand Command { get; set; }
        private void MyMethod(object param)
        {
            // method body
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyKey = Key.OemPeriod;
            Command = new CommandImpl(MyMethod);
        }
        private void myTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            MyKey = Key.None;
        }
        private void myTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            MyKey = Key.OemPeriod;
        }
