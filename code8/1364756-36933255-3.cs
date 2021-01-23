    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3));
        }
    }
