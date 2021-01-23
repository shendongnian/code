    using System.Windows;
    using System.Windows.Media.Animation;
    namespace WpfApplication1
    {    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {           
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(lblError);
            }
        }
    }
