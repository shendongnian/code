    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var viewModel = (ViewModel) this.DataContext;
                Debug.WriteLine(viewModel.TabItems);
                viewModel.AddContentItem();
            }
        }
    }
