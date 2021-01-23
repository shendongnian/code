        public ICommand MyCommand { get; set; }
        Key _myKey ;
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
            MyCommand = new KeyCommand(MyMethod);
            MyKey =  Key.F5;
        }
        public void MyMethod(object param)
        {
            var inputKey = param;
            // do something
        }
