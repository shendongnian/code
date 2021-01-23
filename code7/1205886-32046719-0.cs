        bool _btnIsEnable;
        public bool ButtonIsEnable
        {
            get
            {
                return _btnIsEnable;
            }
            set
            {
                _btnIsEnable = value;
                OnPropertyChanged("ButtonIsEnable");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ButtonIsEnable = true;
        }
