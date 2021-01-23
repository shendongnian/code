    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
    
            this.Loaded += MainPage_Loaded;
        }
    
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var rnd = new Random(444);
            ObservableCollection<Demo> values = new ObservableCollection<Demo>();
            for (int i = 0; i < 15; i++)
            {
                values.Add(new Demo() { Name = (rnd.NextDouble() * 100).ToString(), Pts = i });
            }
            
    
            ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = values;
        }
    }
    
    class Demo
    {
        public string Name { get; set; }
        public double Pts { get; set; }
    }
