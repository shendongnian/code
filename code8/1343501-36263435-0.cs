    protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
    {
        if (args != null && !string.IsNullOrEmpty(args.Arguments))
        {
            // The app was launched from a Secondary Tile
            // Navigate to the item's page
            NavigationService.Navigate("ItemDetail", args.Arguments);
        }
        else
        {
            // Navigate to the initial page
            NavigationService.Navigate("Hub", null);
        }
    
        Window.Current.Activate();
        return Task.FromResult<object>(null);
    }
