    public MainWindow()
        {
        Closing += (s, a) =>
            {
                Properties.Settings.Default.SettingsPopupX = mySettingsPopupObject.GetX();
                Properties.Settings.Default.SettingsPopupY = mySettingsPopupObject.GetY();
                Properties.Settings.Default.Save();
            };
        }
