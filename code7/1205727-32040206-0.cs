        public MainWindow()
        {
            List<KeyValuePair<DateTime, int>> listPrice = new List<KeyValuePair<DateTime, int>>();
            List<KeyValuePair<DateTime, int>> listSMA50 = new List<KeyValuePair<DateTime, int>>();
            List<KeyValuePair<DateTime, int>> listSMA200 = new List<KeyValuePair<DateTime, int>>();
            DateTime d = new DateTime(2000, 1, 1);
            for (int i = 1; i < 10; i++)
            {
                listPrice.Add(new KeyValuePair<DateTime, int>(d, i));
                listSMA50.Add(new KeyValuePair<DateTime, int>(d, i * 2));
                listSMA200.Add(new KeyValuePair<DateTime, int>(d, i * 3));
                d = d.AddDays(1.0);
            }
            var dataSourceList = new List<List<KeyValuePair<DateTime, int>>>();
            dataSourceList.Add(listPrice);
            dataSourceList.Add(listSMA50);
            dataSourceList.Add(listSMA200);
            this.DataContext = dataSourceList;
            InitializeComponent();
        }
