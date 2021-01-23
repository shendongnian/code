    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Thread.Sleep(2000);  // pretending to ping
            Flag = true;
        }
        public bool Flag { get; set; }
    }
