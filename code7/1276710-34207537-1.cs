    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<string> { "Item 1", "Item2" };
            DataContext = this;
        }
    }
