    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                sinBtn.Visibility = Visibility.Visible;
                cosBtn.Visibility = Visibility.Visible;
                logBtn.Visibility = Visibility.Visible;
                eBtn.Visibility = Visibility.Visible;
            }
        }
