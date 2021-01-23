    this.Topmost = true;
    foreach (Window window in Application.Current.Windows)
    {
        if (window.Title != this.Title)
        {
            window.Focusable = false;
            window.WindowStyle = WindowStyle.None;
            window.ResizeMode = ResizeMode.NoResize;
            window.IsEnabled = false;
        }
    }
