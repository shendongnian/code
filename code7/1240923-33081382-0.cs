    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var viewModel = this.DataContext;
                Debug.WriteLine(viewModel.TabItems);
                viewModel.AddContentItem();
            }
        }
    }
