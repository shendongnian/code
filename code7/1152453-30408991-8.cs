    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                this.chWindow.Show();
            }
        }
    }
