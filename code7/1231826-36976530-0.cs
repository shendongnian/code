    /// <summary>
    /// When the window visibility changes
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">VisibilityChangedEventArgs e</param>
    private void OnVisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
        var localSettings = ApplicationData.Current.LocalSettings;
        if (!e.Visible)
        {
            localSettings.Values["AppInForeground"] = false;               
        }
        else
        {
            localSettings.Values["AppInForeground"] = true;
        }
    }
