    protected override bool OnBackButtonPressed()
    {
       if (Device.OS == TargetPlatform.Android)
           DependencyService.Get<IAndroidMethods>().CloseApp();
       return base.OnBackButtonPressed();
    }
