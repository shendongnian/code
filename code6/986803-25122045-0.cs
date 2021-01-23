    public void Browser_Navigated(object sender, NavigationEventArgs e)
    {
        if (e.Uri.AbsolutePath == "/1/oauth/authorize_submit")
		{
			DropboxStorage.CheckAuthentication(
				e.Uri,
				() => NavigationService.GoBack(),
				ex => ShowException(ex));
		}
    }
