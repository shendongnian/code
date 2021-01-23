    using System.Windows;
    using System.Windows.Navigation;
    namespace SOTree
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
            private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
            {
                System.Diagnostics.Process.Start(e.Uri.ToString());
            }
        }
    }
