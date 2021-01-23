    protected override bool OnBackButtonPressed()
    {
       if (Device.RuntimePlatform == Device.Android)
           DependencyService.Get<IAndroidMethods>().CloseApp();
       return base.OnBackButtonPressed();
    }
