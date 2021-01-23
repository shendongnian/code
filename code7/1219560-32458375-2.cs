    public partial class MainWindow : Window
    {
        testWindow testwnd = new testWindow();
        bool frstClick = true;
        public MainWindow()
        {
            InitializeComponent();
            testwnd.Height = 100; //before .Show();
            testwnd.Width = 200; 
            testwnd.Show();
        }
        private void behaviorbtn_Click(object sender, RoutedEventArgs e)
        {
            //After .Show();
            if (testwnd.Height == 400 && testwnd.Width == 500 && frstClick == false) //Second check
            {
                testwnd.Height = 100;
                testwnd.Width = 200;
            }
            if (testwnd.Visibility == Visibility.Visible && frstClick == true) //Runs first
            {
                testwnd.Height = 400;
                testwnd.Width = 500;
                frstClick = false;
            }
        }
    }
