        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            //Navigating to this page when back button is pressed
            NavigationService.Navigate(new Uri("/DisplayPage.xaml", UriKind.Relative));
        }
