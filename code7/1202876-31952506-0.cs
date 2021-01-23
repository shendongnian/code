    public static void TryReveal()
    {
        var mainWindow = Application.Current.MainWindow;
        if (mainWindow == null)
        {
            // The main window has probably been closed.
            // This will stop .Show() and .Activate()
            // from throwing an exception if the window is closed.
            return;
        }
        if (mainWindow.WindowState == WindowState.Minimized)
        {
            mainWindow.WindowState = WindowState.Normal;
        }
        // Reveals if hidden
        mainWindow.Show();
        // Brings to foreground
        mainWindow.Activate();
    }
