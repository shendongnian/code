    void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
            args.Request.ApplicationCommands.Clear();
            // or
            args.Request.ApplicationCommands.RemoveAt(0);
    }
