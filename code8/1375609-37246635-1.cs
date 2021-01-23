    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            var viewModel = new ValuesViewModel();
            viewModel.AddTitleIfUnique("Testing");
            viewModel.AddTitleIfUnique("Testing Again");
            viewModel.AddTitleIfUnique("Testing Again");
            DataContext = viewModel;
        }
    }
