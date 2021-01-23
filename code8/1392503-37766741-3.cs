    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Check if, in the Application.Current.Windows collection 
        // there is at least one window of type SettingsWindow
        SettingsWindow w = Application.Current.Windows
                                      .OfType<SettingsWindow>()
                                      .FirstOrDefault();
        if(w == null)
        {
            // No window of the type required, open a new one....
            w = new SettingsWindow();
            w.Owner = System.Windows.Application.Current.MainWindow;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.Top = this.Top + 20;
        }
        // Show it NON MODALLY....
        w.Show();
    }
