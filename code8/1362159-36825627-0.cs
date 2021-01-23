    protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
    {
        StorageFile dataFile = await Package.Current.InstalledLocation.GetFileAsync("xx.db3");
        await dataFile.CopyAsync(ApplicationData.Current.LocalFolder, "xx.db3", NameCollisionOption.FailIfExists);
        NavigationService.Navigate("Main", null);
        Window.Current.Activate();
    }
