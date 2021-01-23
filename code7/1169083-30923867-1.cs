    public partial class MainWindow : Window
    {
        public ViewModel vm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            this.DataContext = vm;
        }
    }
