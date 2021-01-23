     public partial class MainWindow : Window
    {
        ObservableCollection<listboxData> lst = new ObservableCollection<listboxData>();
        public MainWindow()
        {
            InitializeComponent();
            lbDetails.ItemsSource = lst;
        }
        private void btnDetails_Click_1(object sender, RoutedEventArgs e)
        {
            lst.Add(new listboxData("Textblock" + lst.Count, new SolidColorBrush(Colors.YellowGreen)));
        }
    }
    public class listboxData
    {
        public string text { get; set; }
        public SolidColorBrush bg { get; set; }
        public listboxData(string text, SolidColorBrush bg)
        {
            this.text = text;
            this.bg = bg;
        }
    }
