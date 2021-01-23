    private void settingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateSettings();
            e.Cancel = true;
            main.Show();
            Hide();
        }
    
    private void settingsButton_MouseUp(object sender, RoutedEventArgs e)
        {
            settingsWindow settingsWindow = new settingsWindow(this);
            if (!settingsWindow.settingsOpen)
            {
                settingsWindow.Show();
                Hide();
            }
        }
