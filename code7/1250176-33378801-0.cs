    public partial class MainWindow : Window
    {
        im1 v1 = null;
        im2 v2 = null;
        im3 v3 = null;
        im4 v4 = null;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Random g = new Random();
           int ans = g.Next(1, 5);
            if (ans == 1)
            {
                v1.Close();       
            }
            if (ans == 2)
            {
                v2.Close();
            }
            if (ans == 3) 
            {
                v3.Close();
            }
            if (ans == 4)
            {
                v4.Close();
            }
        }
    
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            v4 = new im4();
            v4.Show();
            v3 = new im3();
            v3.Show();
            v2 = new im2();
            v2.Show();        
            v1 = new im1();
            v1.Show();
        }
    }
