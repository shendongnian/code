    namespace WpfApplication1
    {
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.DataContext = new ViewModel();
                InitializeComponent();
            }
        }
    }
