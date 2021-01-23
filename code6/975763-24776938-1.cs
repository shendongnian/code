    namespace WpfApplication7
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = new MainViewModel(this);
            }
        }
    }
