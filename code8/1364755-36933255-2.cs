    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page2));
        }
    }
