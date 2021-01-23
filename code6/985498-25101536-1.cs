        private ObservableCollection<sample_data> CreateSampleData()
        {
            ObservableCollection<sample_data> sd = new ObservableCollection<sample_data>();
            sd.Add(new sample_data("Bob"));
            sd.Add(new sample_data("Dan"));
            sd.Add(new sample_data("Kate"));
            sd.Add(new sample_data("Bart"));
            sd.Add(new sample_data("Sanders"));
            sd.Add(new sample_data("Dog"));
            return sd;
        }
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            mylonglist.ItemsSource = CreateSampleData();
        }
