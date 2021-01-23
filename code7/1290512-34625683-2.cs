    public partial class MainWindow : Window
        {
            private Serial viewModel;
            public MainWindow()
            {
                InitializeComponent();
                viewModel = new Serial();
                this.DataContext = viewModel;
            }
        }  
