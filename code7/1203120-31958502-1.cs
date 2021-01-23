    // txtDisplay is a TextBlock defined in XAML.
    if (IsolatedStorageSettings.ApplicationSettings.Contains("userData"))
    {
        txtDisplay.Text = IsolatedStorageSettings.ApplicationSettings["userData"] as string;
    }
