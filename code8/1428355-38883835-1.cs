    private void settingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateSettings();
        }
    
    private void settingsButton_MouseUp(object sender, RoutedEventArgs e)
        {
            settingsWindow settingsWindow = new settingsWindow(this);
            if (!settingsWindow.settingsOpen)
            {
                settingsWindow.ShowDialog();
            }
        }
