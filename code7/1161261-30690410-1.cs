    private void Window_Closing(object sender, CancelEventArgs e)
    {
        SaveAppSettings();
    }
    private void LoadAppSettings()
    {
        if (Properties.Settings.Default.LastWindowSize.Width > System.Windows.SystemParameters.WorkArea.Width)
            this.Width = System.Windows.SystemParameters.WorkArea.Width - 1; // stay within screen resolution
        else
            this.Width = Properties.Settings.Default.LastWindowSize.Width;
        if (Properties.Settings.Default.LastWindowSize.Height > System.Windows.SystemParameters.WorkArea.Height)
            this.Height = System.Windows.SystemParameters.WorkArea.Height - 1; // stay within screen resolution
        else
            this.Height = Properties.Settings.Default.LastWindowSize.Height;
        if (Properties.Settings.Default.LastWindowPos.X > 0) // keep it sane, otherwise window appears to disappear
            this.Left = Properties.Settings.Default.LastWindowPos.X;
        if(Properties.Settings.Default.LastWindowPos.Y > 0)
            this.Top = Properties.Settings.Default.LastWindowPos.Y;
    }
    private void SaveAppSettings()
    {
        if (this.WindowState == WindowState.Normal)
        {
            Properties.Settings.Default.LastWindowPos = new System.Drawing.Point((int)this.Left, (int)this.Top);
            Properties.Settings.Default.LastWindowSize = new System.Drawing.Size((int)this.Width, (int)this.Height);
        }
        else
        {
            Properties.Settings.Default.LastWindowPos
               = new System.Drawing.Point((int)this.RestoreBounds.Left, (int)this.RestoreBounds.Top);
            Properties.Settings.Default.LastWindowSize
               = new System.Drawing.Size((int)this.RestoreBounds.Width, (int)this.RestoreBounds.Height);
        }
        Properties.Settings.Default.Save();
    }
