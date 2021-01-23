    public class MainWindow : Window
    {
        [Inject]
        public TrackerViewModel ViewModel { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
