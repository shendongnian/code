    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string str = (string)e.ExtraData;
            // do whatever with str, like assign to a view model field, etc.
        }
    }
