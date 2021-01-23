    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Page1));
        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var lable = (sender as AppBarButton).Label;
            if (lable == "Back")
            {
                if (MyFrame.CanGoBack)
                {
                    MyFrame.GoBack();
                }
            }
            else if (lable == "Forward")
            {
                if (MyFrame.CanGoForward)
                {
                    MyFrame.GoForward();
                }
            }
            else if (lable == "Home")
            {
                MyFrame.Navigate(typeof(Page1));
            }
            
        }
    }
