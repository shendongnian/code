    private async void topBanner_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var tappedItem = Images1a[count1a];
        if (tappedItem.Url != "#")
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(tappedItem.Url));        
        }
    }
