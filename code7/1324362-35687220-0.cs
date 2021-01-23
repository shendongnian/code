    SystemEvents.PowerModeChanged += OnPowerChange;
    
    private void OnPowerChange(object s, PowerModeChangedEventArgs e) 
    {
        switch ( e.Mode ) 
        {
            case PowerModes.Resume:
            // Log the position as it's done in your example
            Logger.Info ("Mode Change: Resume");
            Logger.Info($"{Top},{SettingsHelper.Instance.Settings.WindowTop}");
            break;
            case PowerModes.Suspend:
            Logger.Info ("Mode Change: Suspend");
            Logger.Info($"{Top},{SettingsHelper.Instance.Settings.WindowTop}");
            break;
        }
    }
