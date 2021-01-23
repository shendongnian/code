    private void InventoryUpdater_Loaded(object sender, RoutedEventArgs e)
        {
            TimeSpan na = queueCustomTask();
            Stop = true;
            runManually.IsEnabled = true;
            ssdRunManually.IsEnabled = true;
            startAutoRun.IsEnabled = true;
        }
