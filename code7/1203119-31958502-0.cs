    var settings = IsolatedStorageSettings.ApplicationSettings;
    // txtInput is a TextBox defined in XAML.
    if (!settings.Contains("userData"))
    {
        settings.Add("userData", txtInput.Text);
    }
    else
    {
        settings["userData"] = txtInput.Text;
    }
    settings.Save();
