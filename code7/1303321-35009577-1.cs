    public partial class MainWindow
    {
        public bool Display { get; set; };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // For the binding
            Display = true;
        }
    }
