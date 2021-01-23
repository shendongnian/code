    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SettingsWindow w = Application.Current.Windows
                                      .OfType<SettingsWindow>()
                                      .FirstOrDefault();
        if(w == null)
        {
            w = new SettingsWindow();
            w.Owner = System.Windows.Application.Current.MainWindow;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.Top = this.Top + 20;
        }
        w.Show();
    }
