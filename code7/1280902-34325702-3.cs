    public partial class MainWindow : Window, Interfaces.IMainWindow
    { 
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Interfaces.IMainWindowViewModel context)
        {
            InitializeComponent();
            this.DataContext = context;
        }
    }
