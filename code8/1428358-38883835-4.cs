    private void InventoryUpdater_Loaded(object sender, RoutedEventArgs e)
        {
            settingsWindow settings = new settingsWindow(this);
            sftpSettings severSettings = new sftpSettings(settings);
            TimeSpan na = queueCustomTask();
            Stop = true;
            runManually.IsEnabled = true;
            ssdRunManually.IsEnabled = true;
            startAutoRun.IsEnabled = true;
        }
