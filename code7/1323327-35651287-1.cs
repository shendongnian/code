      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          grdError.Visibility = Visibility.Visible;
        }
    
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          grdError.Visibility = Visibility.Collapsed;
        }
      }
