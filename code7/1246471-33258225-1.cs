    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitData();
            ComboBoxColumn.ItemsSource = CountriesCollection;
            DataGrid.ItemsSource = UsersCollection;
        }
        private void InitData()
        {
            UsersCollection = new ObservableCollection<UserData>(new List<UserData>
            {
                new UserData
                {
                    UName = "Greg",
                },
                new UserData
                {
                    UName = "Joe",
                },
                 new UserData
                {
                    UName = "Iv",
                }
            });
            CountriesCollection = new ObservableCollection<Country>(new List<Country>
            {
                new Country("Ger", "1500"),
                new Country("Fra", "1500"),
                new Country("Ru", "1500"),
                new Country("Bel", "1500"),
            });
        }
        public ObservableCollection<Country> CountriesCollection { get; set; }
        public ObservableCollection<UserData> UsersCollection { get; set; }
    }
