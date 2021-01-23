    if(!IsolatedStorageSettings.ApplicationSettings.Contains("ButtonVisibility"))
    {
        IsolatedStorageSettings.ApplicationSettings.Add("ButtonVisibility", Visibility.Visible.ToString());
    }
    else
    {
        IsolatedStorageSettings.ApplicationSettings["ButtonVisibility"] = Visibility.Visible.ToString());
    }
