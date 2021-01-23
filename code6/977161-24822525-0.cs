    public partial class MainPage : PhoneApplicationPage
    {
        public Product selectedItemData;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            lsttest.ItemsSource = App.lstp;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(@"/Page2.xaml", UriKind.Relative));
        }
        private void lsttest_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            selectedItemData = e.AddedItems[0] as Product;
            NavigationService.Navigate(new Uri(@"/Page2.xaml", UriKind.Relative));
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();
        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);
        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            Page2 destinationpage = e.Content as Page2;
            if (destinationpage != null)
            {
                // Change property of destination page
                destinationpage.GetProduct = selectedItemData;
            }
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //Page2 destinationpage = e.Content as Page2;
            //if (destinationpage != null)
            //{
            //    // Change property of destination page
            //    destinationpage.GetProduct = selectedItemData;
            //}
        }
    }
