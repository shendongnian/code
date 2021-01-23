    public partial class MainWindow : Window
    {
        public ObservableCollection<CalculatedData> calculatedData { get; set; }
        int i;
        public MainWindow()
        {
            InitializeComponent();
            //initialize your binding collection
            calculatedData = new ObservableCollection<CalculatedData>();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            i = 1;
            //create initial data and bind to data grid
            calculatedData = await CalculateData();
            dataGrid1.ItemsSource = calculatedData;
        }
        private Task<ObservableCollection<CalculatedData>> CalculateData()
        {
            return Task.Run(() =>
            {
                ObservableCollection<CalculatedData> cdList = new ObservableCollection<CalculatedData>();
                // Do a lot of stuff
                for (int j = 0; j < 5; j++)
                {
                    cdList.Add(new CalculatedData { Data1 = i, Data2 = i + 1, Data3 = i + 2 });
                    i++;
                }
                return cdList;
            });
        }
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            //place new data in a temporary collection
            ObservableCollection<CalculatedData> newData = await CalculateData();
            //add new data to the collection bound to the data grid
            //preferably, don't just replace it
            //any business logic you may need for adding, 
            //deleting, filtering data, etc goes here 
            foreach (CalculatedData cd in newData)
                calculatedData.Add(cd);
        }
    }
