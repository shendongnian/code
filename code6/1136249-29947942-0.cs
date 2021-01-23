    public partial class MainWindow : Window
    {
        public dataModel _data { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _data = new dataModel();
            this.DataContext = _data;
        }
        private void OnAdd(object sender, RoutedEventArgs e)
        {
            _data.Value3 = _data.Value1 + _data.Value2;
        }
    }
