    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
    }
