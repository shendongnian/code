    var alertConfig = new AlertConfig
    {
        Message = message,
        OkText = "AppSyncViewModel_Alert_Retry".Translate(),
        OnAction = YourAction
    };
    Mvx.IoCProvider.Resolve<IUserDialogs>().Alert(alertConfig);
