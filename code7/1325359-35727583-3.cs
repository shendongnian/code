        /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MyObject> _windows = new ObservableCollection<MyObject>();
        public MainWindow()
        {
            InitializeComponent();
            Windows.Add(new MyObject { Title = "Collection Item 1" });
            Windows.Add(new MyObject { Title = "Collection Item 2" });
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
        public ObservableCollection<MyObject> Windows
        {
            get { return _windows; }
            set { _windows = value; }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Windows.Add(new MyObject { Title = "From Btn" });
        }
    }
    public class MyObject
    {
        public string Title { get; set; }
    }
