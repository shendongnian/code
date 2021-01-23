    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var parameter = e.Parameter as string;
        if (parameter != null && parameter.Equals("connect"))
        {
            // Connect here
        }
        base.OnNavigatedTo(e);
    }
