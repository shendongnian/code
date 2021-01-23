    const string settingsAppLaunched = "appLaunched";
    
    public static bool IsFirstLaunch(){
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        return !(settings.Contains(settingsAppLaunched) && settings[settingsAppLaunched]);
    }
    
    public static bool Launched(){
        if(IsFirstLaunch()){
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Add(settingsAppLaunched, true);
            settings.Save();
        }
    }
    
    //usage:
    if(IsFirstLaunch()){
        showTheFrameToTheGuyBecauseHeLaunchedTheAppForTheFirstTime();
        Launched();
    } 
