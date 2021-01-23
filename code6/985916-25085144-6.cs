    private void LoadSettings(MainWindow window)
    {
        Settings.Default.Reload();
        window.WindowStartupLocation = WindowStartupLocation.Manual;
        window.Left = Settings.Default.ApplicationLocation.X;
        window.Top = Settings.Default.ApplicationLocation.Y;
        window.Width = Settings.Default.ApplicationSize.Width;
        window.Height = Settings.Default.ApplicationSize.Height;
        window.WindowState = Settings.Default.IsApplicationMaximised ? WindowState.Maximized : WindowState.Normal;
    }
    private void SaveSettings(MainWindow window)
    {
        Settings.Default.ApplicationLocation = new Point(window.Left, window.Top);
        Settings.Default.ApplicationSize = new Size(window.Width, window.Height);
        Settings.Default.IsApplicationMaximised = window.WindowState == WindowState.Maximized;
        Settings.Default.Save();
    }
