    public AboutPageViewModel()
    {
        AppName = Settings.Instance.MyAppName;
        Settings.Instance.PropertyChanged += (s,e) =>
        {
            if (e.PropertyName == "MyAppName")
            {
                AppName = Settings.Instance.MyAppName;
            }
        }
    }
