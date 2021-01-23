    public AboutPageViewModel()
    {
        AppName = Settings.Instance.MyAppName;
        Settings.Instance.PropertyChanged += (s,e) =>
        {
            //  If you're in C#6:
            //if (e.PropertyName == nameof(Settings.MyAppName))
            if (e.PropertyName == "MyAppName")
            {
                AppName = Settings.Instance.MyAppName;
            }
        }
    }
