    if (!IsolatedStorageSettings.ApplicationSettings.Contains("FirstStart"))
    {
        //ShowTutorial
    }else
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        if (!settings.Contains("FirstStart"))
        {
            settings.Add("FirstStart", "false");
        }
        //Start normal.
    }
