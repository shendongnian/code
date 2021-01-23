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
            }
    
            private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                MessageBox.Show("Selected" + sender.ToString());
            }
        }
    }
