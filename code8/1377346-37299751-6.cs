    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyViewModelClass viewModel = new MyViewModelClass();
            DataContext = viewModel;
        }
    } 
