    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (PhoneApplicationService.Current.State.ContainsKey("showImage"))
        {
            bool showImage = (bool)PhoneApplicationService.Current.State["showImage"];
            if (showImage)
            {
                this.YourImage.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.YourImage.Visibility = System.Windows.Visibility.Collapsed;
            }
            
            PhoneApplicationService.Current.State.Remove("showImage");
        }
    }
