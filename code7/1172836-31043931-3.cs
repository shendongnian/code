    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModel(); //And this is also important
            InitializeComponent();
        }
    }
