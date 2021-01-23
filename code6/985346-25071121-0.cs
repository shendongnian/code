    void SettingsFlyout1_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Debug.WriteLine(e.NewSize.Width + "," + e.NewSize.Width);
        YourGrid.Width = e.NewSize.Width;
        YourGrid.Height = e.NewSize.Height;
    }
