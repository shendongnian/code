    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainViewModel vm = new MainViewModel();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
   
