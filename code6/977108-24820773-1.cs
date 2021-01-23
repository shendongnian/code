    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (IsolatedStorageSettings.ApplicationSettings.Contains("Font-Size"))
        {
            string fontSize = IsolatedStorageSettings.ApplicationSettings["Font-Size"] as string;     
           
            // Code to set the Font size of your LongListSelector
        }
    }
