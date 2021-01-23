    if(!IsolatedStorageSettings.ApplicationSettings.Contains("first"))
    {
       // Do your stuff
       IsolatedStorageSettings.ApplicationSettings["first"] = true;
       IsolatedStorageSettings.ApplicationSettings.Save();
    }
