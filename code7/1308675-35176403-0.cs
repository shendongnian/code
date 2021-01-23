    if (rootFrame.Content == null)
    {
        IPropertySet roamingProperties = ApplicationData.Current.RoamingSettings.Values;
        if (roamingProperties.ContainsKey("HasBeenHereBefore"))
        {
            // The normal case
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        else
        {
            // The first-time case
            rootFrame.Navigate(typeof(GreetingsPage), e.Arguments);
            roamingProperties["HasBeenHereBefore"] = bool.TrueString; // Doesn't really matter what
        }
    }
