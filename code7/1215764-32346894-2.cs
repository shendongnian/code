        ObservableCollection<CountMsg> dbCount;
        public int CollectionCount
        {
            get
            {
                return dbCount.Count;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            List<CountMsg> retrieved = dbConnCount.Table<CountMsg>().ToList<CountMsg>();
            dbCount = new ObservableCollection<CountMsg>(retrieved);
        }
