    public partial class MainWindow : Window
    {
        public ObservableCollection<string> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            items.Add("test1");
            items.Add("test211111111111111");
            this.DataContext = this;
        }
    }
