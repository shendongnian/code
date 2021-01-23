    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
           private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
            {
                border.Visibility = Visibility.Visible;
            }
    
            private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.MouseDevice.DirectlyOver == rect)
                {
    
                }
                else
                {
                    border.Visibility = Visibility.Hidden;
                }
            }
    
           
        }
