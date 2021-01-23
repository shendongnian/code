    public partial class Window2 : Window
    {
        PieChartViewModel viewModel;
        public Window2()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new PieChartViewModel();
            viewModel.Errors.Add(new TestClass() { Category = "Globalization", Number = 75 });
            viewModel.Errors.Add(new TestClass() { Category = "Features", Number = 2 });
            viewModel.Errors.Add(new TestClass() { Category = "ContentTypes", Number = 12 });
            viewModel.Errors.Add(new TestClass() { Category = "Correctness", Number = 83 });
            viewModel.Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });
            DataContext = viewModel;
        }
    }
