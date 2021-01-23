    protected async override void pickFile(object sender, RoutedEventArgs e) 
    {
        await base.PickFileAsync();
        //need to pick file first
        var properties = await inputFile.Properties.GetVideoPropertiesAsync();
     }
