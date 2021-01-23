    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SampleDataItem item=(sender as Button).DataContext as SampleDataItem;
    if(item!=null){
            string uriToLaunch = "bingmaps:?cp="+item.Latitude+"~"+item.Longitude+"&lvl=10";
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri); 
        }}
