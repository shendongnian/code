    namespace WpfApplication7
    {
        /// <summary>
        /// Logique d'interaction pour MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = new MainViewModel(this);
            }
        }
    }
