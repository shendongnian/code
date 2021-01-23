    public partial class MainWindow : Window
    {
        public ObservableCollection<CalculatedData> calculatedData { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calculatedData = await CalculateData();
            dataGrid1.ItemsSource = calculatedData;
        }
        private Task<ObservableCollection<CalculatedData>> CalculateData()
        {
            return Task.Run(() =>
            {
                ObservableCollection<CalculatedData> cdList = new ObservableCollection<CalculatedData>();
                // Do a lot of stuff
                cdList.Add(new CalculatedData { Data1 = 1, Data2 = 2, Data3 = 3 });
                cdList.Add(new CalculatedData { Data1 = 1, Data2 = 2, Data3 = 3 });
                cdList.Add(new CalculatedData { Data1 = 1, Data2 = 2, Data3 = 3 });
                cdList.Add(new CalculatedData { Data1 = 1, Data2 = 2, Data3 = 3 });
                cdList.Add(new CalculatedData { Data1 = 1, Data2 = 2, Data3 = 3 });
                return cdList;
            });
        }
    }
