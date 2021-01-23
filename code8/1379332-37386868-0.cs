    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // set an initial page for myFrame
            myFrame.Navigate(typeof(Page1));
            // register a handler for myFrame's Navigated event to set the visibility of the Back button
            myFrame.Navigated += myFrame_Navigated;
            // register BackRequested event to handle myFrame's GoBack
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }
        private void myFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ((Frame)sender).CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (myFrame.CanGoBack)
            {
                e.Handled = true;
                myFrame.GoBack();
            }
        }
        private void btnHamburger_Click(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(typeof(SecondPage));
        }
    }
