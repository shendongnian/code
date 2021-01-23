        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string msg1 = "";
            if (NavigationContext.QueryString.TryGetValue("msg1", out msg1))
            {
                textBlock1.Text = String.Format("Signature Anda :{0}", msg1);
            }
        }
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }
