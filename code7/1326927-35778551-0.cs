    protected override void OnAppearing()
    {
        base.OnAppearing();
        activityIndicator.IsVisible = true;
        // Some hard operations
        activityIndicator.IsVisible = false;
    }
