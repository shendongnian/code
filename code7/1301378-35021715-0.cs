    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
        ...
        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(Views.MainPage), e.Arguments);
        }
        // If launched from secondary tile and MainPage already loaded
        else if (!e.TileId.Equals("App") && rootFrame.Content is MainPage)
        {
            // Add a method like this on your MainPage class
            (rootFrame.Content as MainPage).InitializeFromSecondaryTile(e.Arguments);
        }
        ...
