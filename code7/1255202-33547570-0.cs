    public class BackButtonPage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButtonVisibility = base.Frame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().BackRequested += BackButtonPage_BackRequested;
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= BackButtonPage_BackRequested;
        }
        private void BackButtonPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            OnBackRequested(sender, e);
        }
        protected virtual void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            //your page specific code here
            Frame.Navigate(typeof(MainPage));
            e.Handled = true;
        }
        public AppViewBackButtonVisibility BackButtonVisibility
        {
            get { return SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility; }
            set { SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = value; }
        }
    }
